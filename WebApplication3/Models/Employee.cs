﻿namespace WebApplication3.Models
{
    public class Employee
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public int CivilId { get; set; }
        public string? Phone { get; set; }
        public string Position { get; set; }
    
        public BankBranch bankBranch { get; set; }
    }
}
