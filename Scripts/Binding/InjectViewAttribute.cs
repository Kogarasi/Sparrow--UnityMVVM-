using System;

namespace Sparrow.Binding{

	[AttributeUsage( AttributeTargets.Field, AllowMultiple = false)]
	public class InjectViewAttribute : Attribute {
		public string objectName;

		public InjectViewAttribute( string objectName ){
			this.objectName = objectName;
		}
	}
}