using Homework_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_5.Repositories
{
    public class EntriesRepository
    {
        public static EntriesRepository Instance { get; } = new EntriesRepository();

        public List<Entry> Entries = new List<Entry>
        {
            new Entry{Id = 1, Date = DateTime.Now, ExerciseType = Entry.Exercise.Jogging, Duration = 30 },
            new Entry{Id = 2, Date = DateTime.Now, ExerciseType = Entry.Exercise.Cycling, Duration = 40 },
            new Entry{Id = 3, Date = DateTime.Now, ExerciseType = Entry.Exercise.Walking, Duration = 60 }
        };

        private int runningId;

        public EntriesRepository()
        {
            runningId = Entries.Count + 1;
        }

        public List<Entry> GetEntries()
        {
            return Entries;
        }

        public void AddEntry(Entry entry)
        {
            Entry newEntry = new Entry
            {
                Id = runningId,
                Date = DateTime.Now,
                ExerciseType = entry.ExerciseType,
                Duration = entry.Duration
            };

            Entries.Add(newEntry);
            runningId++;
        }
    }
}
