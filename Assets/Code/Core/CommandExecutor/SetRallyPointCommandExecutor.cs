﻿using System.Threading.Tasks;
using Interfaces;

public class SetRallyPointCommandExecutor : CommandExecutorBase<ISetRallyPointCommand>
{
    public override async Task ExecuteSpecificCommand(ISetRallyPointCommand command)
    {
        GetComponent<BuildingSelector>().RallyPoint = command.RallyPoint;
    }
}
