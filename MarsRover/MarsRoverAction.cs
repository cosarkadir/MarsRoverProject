using System;
using System.Linq;

namespace MarsRover
{
    /// <summary>
    /// Komutlara göre robotun hareketini sağlayan sınıf
    /// </summary>
    public class MarsRoverAction
    {
        /// <summary>
        /// Robot hareketlerini sağlayan metod
        /// </summary>
        /// <param name="marsPlateau">Mars yüzeyi input değeri</param>
        /// <param name="robot1Position">Robot1'in X koordinatı input değeri</param>
        /// <param name="robot1Command">Robot1'nin komutları</param>
        /// <param name="robot2Position">Robot2'in Y koordinatı input değeri</param>
        /// <param name="robot2Command">Robot2'nin komutları</param>
        /// <returns></returns>
        public string Action(string marsPlateau, string robot1Position, string robot1Command, string robot2Position, string robot2Command)
        {
            #region Input kontrolleri
            if (string.IsNullOrEmpty(marsPlateau))
            {
                throw new ArgumentException("Mars yüzeyi input değeri boş olamaz!");
            }
            if (string.IsNullOrEmpty(robot1Position))
            {
                throw new ArgumentException("Robot1'in posizyon bilgileri boş olamaz!");
            }
            if (string.IsNullOrEmpty(robot1Command))
            {
                throw new ArgumentException("Robot1'in komut bilgileri boş olamaz!");
            }
            if (string.IsNullOrEmpty(robot2Position))
            {
                throw new ArgumentException("Robot2'in pozisyon bilgileri boş olamaz!");
            }
            if (string.IsNullOrEmpty(robot2Command))
            {
                throw new ArgumentException("Robot2'in komut bilgileri boş olamaz!");
            }

            string[] marsPlateauArray = marsPlateau.Split(' ');
            string[] robot1PositionArray = robot1Position.Split(' ');
            string[] robot2PositionArray = robot2Position.Split(' ');

            int marsPlateauX;
            int marsPlateauY;
            int robot1PositionX;
            int robot1PositionY;
            int robot2PositionX;
            int robot2PositionY;
            //Mars yüzeyi input değerleri kontrolü
            //X ve Y koordinatları olmak üzere 2 integer değer olmalı. Aralarında 1 boşluk olmalı.
            if (marsPlateauArray.Length != 2 || !int.TryParse(marsPlateauArray[0], out marsPlateauX) || !int.TryParse(marsPlateauArray[1], out marsPlateauY))
            {
                throw new ArgumentException("Mars yüzeyi input değerleri hatalı!");
            }
            if (robot1PositionArray.Length!=3 || !int.TryParse(robot1PositionArray[0], out robot1PositionX)|| !int.TryParse(robot1PositionArray[1], out robot1PositionY)|| !Enum.IsDefined(typeof(Direction), robot1PositionArray[2])
                )
            {
                throw new ArgumentException("Robot1 pozisyon input değerleri hatalı!");
            }
            if (robot2PositionArray.Length != 3 || !int.TryParse(robot2PositionArray[0], out robot2PositionX) || !int.TryParse(robot2PositionArray[1], out robot2PositionY) || !Enum.IsDefined(typeof(Direction), robot2PositionArray[2]))
            {
                throw new ArgumentException("Robot2 pozisyon input değerleri hatalı!");
            }
            if (robot1Command.Any(x=>x.ToString() != RobotAct.L.ToString() && x.ToString() != RobotAct.R.ToString()&& x.ToString() != RobotAct.M.ToString()))
            {
                throw new ArgumentException("Robot1 komut değerleri hatalı!");
            }
            if (robot2Command.Any(x => x.ToString() != RobotAct.L.ToString() && x.ToString() != RobotAct.R.ToString() && x.ToString() != RobotAct.M.ToString()))
            {
                throw new ArgumentException("Robot2 komut değerleri hatalı!");
            }

            Direction robot1Direction = (Direction)Enum.Parse(typeof(Direction), robot1PositionArray[2]);
            Direction robot2Direction = (Direction)Enum.Parse(typeof(Direction), robot2PositionArray[2]);
            #endregion

            Invoker invoker = new Invoker(marsPlateauX, marsPlateauY);
            Robot robot1 = new Robot(robot1PositionX, robot1PositionY, robot1Direction);
            foreach (char command in robot1Command.ToCharArray())
            {
                if (command.ToString() == RobotAct.L.ToString())
                {
                    invoker.AddCommand(new TurnLeftCommand(robot1));
                }
                else if (command.ToString() == RobotAct.R.ToString())
                {
                    invoker.AddCommand(new TurnRightCommand(robot1));
                }
                else if (command.ToString() == RobotAct.M.ToString())
                {
                    invoker.AddCommand(new TakeStepCommand(robot1));
                }
            }

            Robot robot2 = new Robot(robot2PositionX, robot2PositionY, robot2Direction);
            foreach (char command in robot2Command.ToCharArray())
            {
                if (command.ToString() == RobotAct.L.ToString())
                {
                    invoker.AddCommand(new TurnLeftCommand(robot2));
                }
                else if (command.ToString() == RobotAct.R.ToString())
                {
                    invoker.AddCommand(new TurnRightCommand(robot2));
                }
                else if (command.ToString() == RobotAct.M.ToString())
                {
                    invoker.AddCommand(new TakeStepCommand(robot2));
                }
            }

            invoker.ExecuteAll();

            return $"{robot1.X} {robot1.Y} {robot1.Direction}{Environment.NewLine}{robot2.X} {robot2.Y} {robot2.Direction}";
        }
    }
}
