using System;
using System.Collections.Generic;
using MpmClient.Api;

namespace MpmClient.Modules.Users.Views.Interface
{
    internal interface IEmployeeList
    {
        event EventHandler LoadEmployeeList;

        void SetEmployeesData(ICollection<UserEmployee> data);
    }
}
