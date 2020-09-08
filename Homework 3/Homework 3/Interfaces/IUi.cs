using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_3.Interfaces
{
    public interface IUi
    {
        public delegate void EmptyEvent();
        public delegate void SearchEvent(string searchTerm);

        public event SearchEvent Search;
        public event EmptyEvent Add;
        public event EmptyEvent Remove;
    }
}
