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
		private IList<string> GetLatestCommitMessages(Uri repository, int count = 10) {
			using (var client = new SvnClient()) {
				System.Collections.ObjectModel.Collection<SvnLogEventArgs> logEntries;
				var args = new SvnLogArgs() {
					Limit = count
				};
				client.GetLog(repository, args, out logEntries);
				return logEntries.Select(log => log.LogMessage).ToList();
			}
		}

		public IList<string> GetLogMessages(Uri repository) {
			return GetLatestCommitMessages(repository);
		}
	}
}
