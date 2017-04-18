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
		private IList<string> GetLatestCommitMessages(Uri repository, int start) {
			using (var client = new SvnClient()) {
				System.Collections.ObjectModel.Collection<SvnLogEventArgs> logEntries;
				//var args = new SvnLogArgs() {
				//	Start = start
				//};
				DateTime startDateTime = new DateTime(2017, 03, 20);
				DateTime endDateTime = DateTime.Now;
				SvnRevisionRange range = new SvnRevisionRange(new SvnRevision(startDateTime), new SvnRevision(endDateTime));
				client.GetLog(repository, new SvnLogArgs(range), out logEntries);
				return logEntries.Where(log => log.LogMessage.Contains("#SD-3606")).Select(log => log.LogMessage).ToList();
			}
		}

		public IList<string> GetLogMessages(Uri repository) {
			return GetLatestCommitMessages(repository, 120640);
		}
	}
}
