using System;

namespace BLL.DTO
{
    public class SandboxDTO
    {
        public int Id { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}