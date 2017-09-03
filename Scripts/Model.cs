using System.Linq;
using UnityEngine;

namespace Sparrow {

	public class Model<T>: ModelBase where T: Model<T>, new() {
		static T _instance;

		public static T instance {
			get {
				if(_instance == null ){
					_instance = new T();
				}
				return _instance;
			}
		}

		public string getPrefabPathFromAttribute( object obj ){
			var attrs = obj.GetType().GetCustomAttributes( typeof( Binding.PrefabAttribute ), true );
			var attr = attrs.First() as Binding.PrefabAttribute;
			return attr.path;
		}

		public override void Dispose(){
			if(!isDisposed){
				base.Dispose();

				_instance = null;
			}
		}
	}
}