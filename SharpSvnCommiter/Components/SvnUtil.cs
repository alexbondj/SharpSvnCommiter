using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpSvn;

namespace SharpSvnCommiter.Components
{
	public class SvnUtil
	{

		public SvnUtil(DateTime start, DateTime end)
		{
			Start = start;
			End = end;
		}

		public DateTime Start { get; private set; }

		public DateTime End { get; private set; }

		private IList<string> GetLatestCommitMessages(Uri repository) {
			using (var client = new SvnClient()) {
				System.Collections.ObjectModel.Collection<SvnLogEventArgs> logEntries;
				
				SvnRevisionRange range = new SvnRevisionRange(new SvnRevision(Start), new SvnRevision(End));
				var args = new SvnLogArgs(range);
				client.GetLog(repository, args, out logEntries);
				return logEntries.Where(log => log.LogMessage.Contains("#SD-3606")).Select(log => log.LogMessage).ToList();
			}
		}

		public IList<string> GetLogMessages(Uri repository) {
			return GetLatestCommitMessages(repository);
		}
	}
}
