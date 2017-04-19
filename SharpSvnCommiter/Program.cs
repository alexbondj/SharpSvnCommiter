using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpSvnCommiter.Components;

namespace SharpSvnCommiter
{
	class Program
	{
		static void Main(string[] args) {
			DateTime startDateTime = new DateTime(2017, 03, 20);
			DateTime endDateTime = DateTime.Now;
			var svnUtil = new SvnUtil(startDateTime, endDateTime);
			var messages = svnUtil.GetLogMessages(new Uri(@"http://tscore-svn:8050/svn/ts5conf/PackageStore"));
			Console.WriteLine(messages);
			Console.ReadKey();
		}
	}
}
