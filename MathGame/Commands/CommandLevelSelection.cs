namespace MathGame.Commands
{
    public class CommandLevelSelection : CommandBase
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            //parameter = new LevelSelection();
        }
    }
}
