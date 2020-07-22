namespace MarsRover
{
    /// <summary>
    /// Sağa dönme komutu sınıfı
    /// </summary>
    public class TurnRightCommand : IRobotCommand
    {
        private readonly Robot _robot;

        /// <summary>
        /// Sağa dönme komutu sınıfı
        /// </summary>
        /// <param name="robot">Robot nesnesi</param>
        public TurnRightCommand(Robot robot)
        {
            _robot = robot;
        }
        public void Execute()
        {
            _robot.TurnRight();
        }
    }
}
