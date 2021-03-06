﻿using System;
using System.Collections.Generic;
using addressbook_tests_autoit.model;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEGROUPWINTITLE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        internal int GetGroupCount()
        {
            OpenGroupsDialog();
            int count = int.Parse(aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", ""));
            CloseGroupsDialog();
            return count;
            
        }

        internal List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialog();
            int count = int.Parse(aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", ""));
            for (int i =0; i < count;i++)
            {
                
                string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", 
                    "GetText", "#0|#"+i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });


            }
            CloseGroupsDialog();
            return list;
        }

        internal void AddGroup(GroupData newGroup)
        {
            OpenGroupsDialog();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ Eneter}");
            CloseGroupsDialog();
        }

        internal void DeleteGroup(int index)
        {
            OpenGroupsDialog();
            Delete(index);
            CloseGroupsDialog();
        }

        private void CloseGroupsDialog()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDialog()
        {
            aux.WinWait(WINTITLE);
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }

        private void Select(int index)
        {
            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                   "Select", "#0|#" + index, "");
        }

        private void Delete(int index)
        {
            Select(index);
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait(DELETEGROUPWINTITLE);
            aux.ControlClick(DELETEGROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            
        }
    }
}