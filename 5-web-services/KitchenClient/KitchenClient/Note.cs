using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenClient
{
    public class Note
    {
        public int Id { get; set; }

        public User Author { get; set; }

        public string Text { get; set; }
    }
}
