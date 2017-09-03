using System;
using UnityEngine;

namespace Sparrow.Binding {
	public class PrefabAttribute : Attribute {
		public string path;

		public PrefabAttribute( string path ){
			this.path = path;
		}
	}
}