using System.Collections.Generic;

namespace MarsRover
{
    public class Invoker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="marsPlateauX">Mars yüzeyi X koordinat değeri</param>
        /// <param name="marsPlateauY">Mars yüzeyi Y koordinat değeri</param>
        public Invoker(int marsPlateauX, int marsPlateauY)
        {
            MarsPlateau.X = marsPlateauX;
            MarsPlateau.Y = marsPlateauY;
        }

        private Queue<IRobotCommand> _commandList = new Queue<IRobotCommand>();

        /// <summary>
        /// Siradaki komutu çalıştırır
        /// </summary>
        public void Execute()
        {
            _commandList.Dequeue().Execute();
        }

        /// <summary>
        /// Bütün komutları çalıştırır
        /// </summary>
        public void ExecuteAll()
        {
            while (_commandList.Count > 0)
                _commandList.Dequeue().Execute();
        }

        /// <summary>
        /// Komut ekler
        /// </summary>
        /// <param name="command"></param>
        public void AddCommand(IRobotCommand command)
        {
            _commandList.Enqueue(command);
        }
    }
}
