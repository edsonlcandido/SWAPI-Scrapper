﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI_Scrapper.Commands
{
    public interface ICommandHandler<TCommand> where TCommand : Commands.ICommand
    {
        Task Handle(TCommand command);
    }
}
