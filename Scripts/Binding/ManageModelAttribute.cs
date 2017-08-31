using System;

namespace Sparrow.Binding {

	[AttributeUsage( AttributeTargets.Class, AllowMultiple = true)]
	public class ManageModelAttribute : Attribute {
		public Type type;

		public ManageModelAttribute( Type type ){
			this.type = type;
		}
	}
}