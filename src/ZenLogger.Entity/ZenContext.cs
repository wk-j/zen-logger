using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ZenLogger.Entity {
    public enum LogLevel {
        Trace, Debug, Info, Error
    }

    public class LogInfo {
        [Key]
        public int Id { set; get; }
        public LogLevel LogLevel { set; get; }
        public string Message { set; get; }
        public DateTime DateTime { set; get; } = DateTime.Now;
        public string Application { set; get; }
        public string Ip { set; get; }
    }

    public class ZenContext : DbContext {
        public ZenContext(DbContextOptions options) : base(options) { }
        public DbSet<LogInfo> LogInfos { set; get; }
    }
}
