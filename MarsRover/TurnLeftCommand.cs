namespace MarsRover
{
    /// <summary>
    /// Sola dönme komutu sınıfı
    /// </summary>
    public class TurnLeftCommand : IRobotCommand
    {
        private readonly Robot _robot;

        /// <summary>
        /// Sola dönme komutu sınıfı
        /// </summary>
        /// <param name="robot">Robot nesnesi</param>
        public TurnLeftCommand(Robot robot)
        {
            _robot = robot;
        }
        public void Execute()
        {
            _robot.TurnLeft();
        }
    }
}
