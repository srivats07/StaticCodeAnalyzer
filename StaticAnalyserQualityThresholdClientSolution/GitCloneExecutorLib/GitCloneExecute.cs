using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitCommandExecuteLib;

namespace GitCloneExecutorLib
{
    public class GitCloneExecute:IGitCommandExecute
    {
        public void Execute(string url)
        {
            string gitCommand = "git";
            string gitCloneArgument = @"clone " + url;
            Process.Start(gitCommand,gitCloneArgument);
        }
    }
}
