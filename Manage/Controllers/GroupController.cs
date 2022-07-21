using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manage.Controllers
{
    public class GroupController
    {
        private GroupRepository _groupRepository = new GroupRepository();

        public GroupController()
        {

        }

        public void CreateGroup()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter group name");
            string name = Console.ReadLine();
            MaxSize: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter group max size");
            string size = Console.ReadLine();
            int maxSize;
            bool result = int.TryParse(size, out maxSize);
            if (result)
            {
                Group group = new Group
                {
                    Name = name,
                    MaxSize = maxSize
                };
                _groupRepository.Create(group);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{group.Name} is succesfully created with max size - {group.MaxSize}");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct group maxsize");
                goto MaxSize;
            }
        }

        public void UpdateGroup()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter group name:");
            string name = Console.ReadLine();
            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());
            if (group != null) 
            {
                int oldSize = group.MaxSize;
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter new group name");
                string newName = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter new group size");
                string size = Console.ReadLine();

                int maxSize;
                bool result = int.TryParse(size, out maxSize);

                if (result)
                {
                    var newGroup = new Group
                    {
                        Id = group.Id,
                        Name = newName,
                        MaxSize = maxSize
                    };
                    _groupRepository.Update(newGroup);
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"{newName} is updated, new max size:{maxSize}, old max size:{oldSize}, name:{name}");
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, write correct group name");
                }
            }
        }

        public void DeleteGroup()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter group name:");
            string name = Console.ReadLine();
            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());

            if (group!=null)
            {
                _groupRepository.Delete(group);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{name} is deleted");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
            }
        }

        public void GetGroupByName()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter group name:");
            string name = Console.ReadLine();

            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());
            if (group != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"Name:{name}, Maxsize:{group.MaxSize}");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
            }
        }

        public void Exit()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Thanks for using Application");
        }
        
    }
}
