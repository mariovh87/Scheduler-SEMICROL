﻿using System;
using EnsureThat;

namespace Scheduler.Domain.Entities
{
    public class Limits
    {
        internal DateTime startDate;
        internal DateTime? endDate;
        public Limits(DateTime startDate, DateTime? endDate)
        {
            this.ValidateDates();
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public static Limits New(DateTime startDate, DateTime? endDate)
        {
            return new Limits(startDate, endDate);
        }

        private void ValidateDates()
        {
            Ensure.That(startDate).HasValue();
            if (endDate.HasValue)
            {
                Ensure.That<DateTime>(startDate).IsGt(endDate.Value);
            }
        }
    }
}