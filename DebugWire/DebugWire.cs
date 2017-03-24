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
        const byte CMD_BREAK        = 0x00;
        const byte CMD_RESUME       = 0x30;
        const byte CMD_RESET        = 0x07;
        const byte CMD_DISABLE_DW   = 0x06;
        const byte CMD_GET_FUSE     = 0xf3;

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
        /// Reads the signataure of the target and returns it as a byte array.
        /// </summary>
        /// <returns>A byte array containing the target signature.</returns>
        public async Task<byte[]> getSignatureRaw()
        {
            return await write_cmd(CMD_GET_FUSE, 2);
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
