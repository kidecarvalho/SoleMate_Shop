﻿namespace SoleMate.Infrastructure
{
    public class ContactForm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime DateSubmitted { get; set; }

    }
}