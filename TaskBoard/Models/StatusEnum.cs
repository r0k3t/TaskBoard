using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskBoard.Models
{
    public enum TaskStatus
    {
        Backlog,
        Design,
        Developement,
        QA,
    }

    public enum ProjectEnum
    {
        Open,
        Closed
    }
}