/*   Copyright (C)  2017  Jan Böhmer
*
*    This program is free software; you can redistribute it and/or modify
*    it under the terms of the GNU General Public License as published by
*    the Free Software Foundation; either version 2 of the License, or
*    (at your option) any later version.
*
*    This program is distributed in the hope that it will be useful,
*    but WITHOUT ANY WARRANTY; without even the implied warranty of
*    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
*    GNU General Public License for more details.
*
*    You should have received a copy of the GNU General Public License along
*    with this program; if not, write to the Free Software Foundation, Inc.,
*    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace DebugWire
{
    public class DebugWire
    {
        int _fcpu;
        SerialPort _port;
        int _sleeptime;

        private object serialincoming = new Object();

        //DebugWire Command bytes
        //Basic commands
        const byte CMD_BREAK        = 0x00;
        const byte CMD_RESUME       = 0x30;
        const byte CMD_RESET        = 0x07;
        const byte CMD_DISABLE_DW   = 0x06;
        const byte CMD_SS           = 0x31;
        //Read Data
        const byte CMD_GET_PC       = 0xf0;
        const byte CMD_GET_HWBP     = 0xf1;
        const byte CMD_GET_INSTR    = 0xf2;
        const byte CMD_GET_SIG      = 0xf3;
        //Write Data
        const byte CMD_SET_PC       = 0xd0;
        const byte CMD_SET_HWBP     = 0xd1;
        const byte CMD_SET_INSTR    = 0xd2;
        //Results
        const byte RESULT_OK        = 0x55;

        /// <summary>
        /// Creates and opens an new debugwire connection
        /// </summary>
        /// <param name="portname">The serial port the MCU is connected to.</param>
        /// <param name="F_CPU">The CPU frequency in Hz.</param>
        public DebugWire(string portname, int F_CPU)
        {
            _sleeptime = 20;
            if(F_CPU <= 0)
            {
                throw new ArgumentException("F_CPU has to be greater 0.");
            }
            _fcpu = F_CPU;
            var baud = get_baud();

            _port = new SerialPort(portname, baud);
            _port.Open();
        }

        /// <summary>
        /// Halts the target with a break.
        /// </summary>
        /// <returns>true if the halt was successful, false if not.</returns>
        public async Task<bool> halt()
        {
            var b = await write_cmd(CMD_BREAK, 1);
            if(b[0] == RESULT_OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Resume the execution on the target after a break;
        /// </summary>
        /// <returns></returns>
        public async Task resume()
        {
            await write_cmd(CMD_RESUME, 0);
        }

        /// <summary>
        /// Resets the target and restart it.
        /// </summary>
        /// <returns>true if the reset was successful.</returns>
        public async Task<bool> reset()
        {
            return await reset(true);
        }

        /// <summary>
        /// Disables DebugWire on the target and reactivate ISP.
        /// After this command you can not use DebuWire until deactivate and activate power.
        /// </summary>
        /// <returns>true if the disabling was successful.</returns>
        public async Task<bool> disableDW()
        {
            var result = await write_cmd(CMD_DISABLE_DW, 2);
            if (result[2] == RESULT_OK)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Resets the target and restart it if desired.
        /// </summary>
        /// <param name="start">true if the target should be restart after reset. If set to false the target must be restarted manually with call of halt()</param>
        /// <returns></returns>
        public async Task<bool> reset(bool start)
        {
            var a = await write_cmd(CMD_RESET, 3);
            if (a[2] != RESULT_OK)
                return false;

            if (start) // The MCU is stopped, send 0x00 to restart it
            {
                var b = await write_cmd(0x00, 1);
                if (b[0] != RESULT_OK)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Performs only the next instructions on the target. (Single Stepping).
        /// </summary>
        /// <returns>true if the single step was successful.</returns>
        public async Task<bool> singleStep()
        {
            var result = await write_cmd(CMD_SS, 3);
            if (result[2] == RESULT_OK)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Reads the signataure of the target and returns it as a byte array.
        /// </summary>
        /// <returns>A byte array containing the target signature.</returns>
        public async Task<byte[]> getSignatureRaw()
        {
            return await write_cmd(CMD_GET_SIG, 2);
        }

        /// <summary>
        /// Reads the signature of the target and returns it as Signature object.
        /// </summary>
        /// <returns>A Signature object describing the target signature</returns>
        public async Task<Signature> getSignature()
        {
            return new Signature(await getSignatureRaw());   
        }


        /// <summary>
        /// Reads the value of the Programm Counter (PC) from the target.
        /// It contains the current address, which is executed.
        /// </summary>
        /// <returns>The value of the PC.</returns>
        public async Task<Address> getPC()
        {
            var result = await write_cmd(CMD_GET_PC, 2);
            return new Address(result);
        }

        /// <summary>
        /// Reads the value of the Programm Counter (PC) from the target and return it as byte array.
        /// It contains the current address, which is executed.
        /// </summary>
        /// <returns>A byte array containing the address.</returns>
        public async Task<byte[]> getPCRaw()
        {
            var addr = await write_cmd(CMD_GET_PC, 2);
            return addr;
        }

        /// <summary>
        /// Reads the value of the Hardware Breakpoint from target and returns it as byte array.
        /// </summary>
        /// <returns>A byte array containing the read address.</returns>
        public async Task<byte[]> getHWBPRaw()
        {
            return await write_cmd(CMD_GET_HWBP, 2);
        }

        /// <summary>
        /// Reads the value of the Hardware Breakpoint from target and returns it as Address object.
        /// </summary>
        /// <returns></returns>
        public async Task<Address> getHWBP()
        {
            return new Address(await getHWBPRaw());
        }

        /// <summary>
        /// Calculates a suitable baudrate for the DebugWire port.
        /// </summary>
        /// <returns>The calculated baudrate.</returns>
        private int get_baud()
        {
            return _fcpu / 128;
        }

        /// <summary>
        /// Outputs the given cmds and data to the MCU and receive the given amount of bytes. Waits the given time before reading the  
        /// </summary>
        /// <param name="cmd">The commands and the data, which should be sent, as byte array.</param>
        /// <param name="expected_bytes">How many bytes should be received, after transmission of the command.</param>
        /// <param name="sleeptime">Time in ms, how long should be waited before read targets answer.</param>
        /// <returns>A byte array with the targets answer</returns>
        private async Task<byte[]> write_cmd(byte[] cmd, int expected_bytes, int sleeptime)
        {
            if (cmd.Length == 0)
                throw new ArgumentException("cmd must contain at least one command byte!");
            if (expected_bytes < 0)
                throw new ArgumentException("expected_bytes must be greater 0!");
            if (sleeptime < 0)
                throw new ArgumentException("sleeptime must be greater 0!");

            _port.DiscardInBuffer(); // Discard all existing bytes, so we dont get results from the last one
            _port.Write(cmd, 0, cmd.Length);
            byte[] buffer = new byte[cmd.Length + expected_bytes];
            if (expected_bytes > 0) // Sleep only if we really want to receive data
            {
                Thread.Sleep(sleeptime); // We need this, because SerialPort reads faster, than the MCU can answer
            }
            await _port.BaseStream.ReadAsync(buffer, 0, cmd.Length + expected_bytes);
            byte[] result = new byte[expected_bytes];
            for(int i = cmd.Length;i<buffer.Length;i++) //buffer contains the sended bytes, so copy only the result bytes into a new array
            {
                result[i - cmd.Length] = buffer[i];
            }
            return result;
        }

        /// <summary>
        /// Outputs the given cmds and data to the MCU and receive the given amount of bytes.
        /// </summary>
        /// <param name="cmd">The commands and the data, which should be sent, as byte array.</param>
        /// <param name="expected_bytes">How many bytes should be received, after transmission of the command.</param>
        /// <returns>A byte array with the targets answer</returns>
        private async Task<byte[]> write_cmd(byte[] cmd, int expected_bytes)
        {
            return await write_cmd(cmd, expected_bytes, _sleeptime);
        }

        /// <summary>
        /// Outputs the given cmd to the MCU and receive the given amount of bytes.
        /// </summary>
        /// <param name="cmd">The command which should be sent.</param>
        /// <param name="expected_bytes">How many bytes should be received, after transmission of the command.</param>
        /// <returns>A byte array with the targets answer</returns>
        private async Task<byte[]> write_cmd(byte cmd, int expected_bytes)
        {
            byte[] b = { cmd };
            return await write_cmd(b, expected_bytes);
        }

        /// <summary>
        /// Outputs the given cmd to the MCU and receive the given amount of bytes. Waits the given time before reading the  
        /// </summary>
        /// <param name="cmd">The command which should be sent.</param>
        /// <param name="expected_bytes">How many bytes should be received, after transmission of the command.</param>
        /// <param name="sleeptime">Time in ms, how long should be waited before read targets answer.</param>
        /// <returns>A byte array with the targets answer</returns>
        private async Task<byte[]> write_cmd(byte cmd, int expected_bytes, int sleeptime)
        {
            byte[] b = { cmd };
            return await write_cmd(b, expected_bytes, sleeptime);
        }


    }

}
