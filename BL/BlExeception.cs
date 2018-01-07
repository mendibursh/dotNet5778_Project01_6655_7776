using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BL
{
	[Serializable]
	 public class BlExeception :Exception
	{
			public BlExeception() : base() { }
			public BlExeception(string message) : base(message) { }
			public BlExeception(string message, Exception inner) : base(message, inner) { }
			protected BlExeception(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}

}
