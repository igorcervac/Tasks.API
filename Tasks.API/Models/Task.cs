﻿namespace Tasks.API.Models
{
    public class Task : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
