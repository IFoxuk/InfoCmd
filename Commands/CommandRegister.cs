using LLNET.DynamicCommand;

namespace InfoCmd.Commands
{
    using ParamType = LLNET.DynamicCommand.DynamicCommand.ParameterType;

    internal class CommandRegister: IExecute
    {
        public void Execute()
        {
            DynamicCommand.RegisterCommand<InfoCommand>();
        }
    }
}
