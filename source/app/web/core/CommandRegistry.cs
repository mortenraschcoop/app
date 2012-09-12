﻿using System.Collections.Generic;
using System.Linq;
using app.web.core.stubs;

namespace app.web.core
{
  public class CommandRegistry : IFindCommandsForRequests
  {
    IEnumerable<IProcessARequest> all_commands;
    IProcessARequest special_case;

    public CommandRegistry(IEnumerable<IProcessARequest> all_commands, IProcessARequest special_case)
    {
      this.all_commands = all_commands;
      this.special_case = special_case;
    }

    public CommandRegistry():this(new StubSetOfCommands(),new StubMissingCommand())
    {
    }

    public IProcessARequest get_the_command_that_can_process_The_request(IEncapsulateRequestDetails request)
    {
      var command = this.all_commands.SingleOrDefault(x => x.can_process(request));
      if (command == null)
        return special_case;

      return command;
    }
  }
}