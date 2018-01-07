using System;
using System.Runtime.Serialization;

namespace DAL
{
	[Serializable]
	internal class DALExeption : Exception
	{
		public DALExeption()
		{
		}

		public DALExeption(string message) : base(message)
		{
		}

		public DALExeption(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected DALExeption(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}