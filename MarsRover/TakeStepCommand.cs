namespace MarsRover
{
    /// <summary>
    /// Atım atma komutu sınıfı
    /// </summary>
    public class TakeStepCommand : IRobotCommand
    {
        private readonly Robot _robot;

        /// <summary>
        /// Atım atma komutu sınıfı
        /// </summary>
        /// <param name="robot">Robot nesnesi</param>
        public TakeStepCommand(Robot robot)
        {
            _robot = robot;
        }
        public void Execute()
        {
            _robot.TakeStep();
        }
    }
}
