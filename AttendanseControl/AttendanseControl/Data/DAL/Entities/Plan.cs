﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Plan
    {
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }

        public IPlanState state { get; set; }

        public Plan()
        {
            state = new Plan();
        }

        public void nextState()
        {
            state.NextStep(this);
        }

        public void prevState()
        {
            state.CancelLast(this);
        }

    }
}
