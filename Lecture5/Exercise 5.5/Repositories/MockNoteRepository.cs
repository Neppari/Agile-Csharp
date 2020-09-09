using Exercise_5._5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_5._5.Repositories
{
    public class MockNoteRepository
    {
        public MockNoteRepository()
        {
            Notes = DummyNotes();
        }

        public static MockNoteRepository Instance { get; } = new MockNoteRepository();

        private List<Note> Notes { get; set; }

        public List<Note> GetNotes() => Notes;

        public void AddNote (Note note)
        {
            Notes.Add(note);
        }

        static List<Note> DummyNotes()
        {
            List<Note> dummies = new List<Note>
            {
                new Note(1, "Today, I ate pizza.", "Meri"),
                new Note(2, "It is sunny!", "Meri")
            };

            return dummies;
        }
    }
}
