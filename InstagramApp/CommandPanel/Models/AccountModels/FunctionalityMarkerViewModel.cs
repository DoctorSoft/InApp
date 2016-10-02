using System;
using Constants;

namespace CommandPanel.Models.AccountModels
{
    public class FunctionalityMarkerViewModel
    {
        public FunctionalityName FunctionalityName { get; set; }

        public DateTime LastActivation { get; set; }

        public bool IsActive { get; set; }
    }
}