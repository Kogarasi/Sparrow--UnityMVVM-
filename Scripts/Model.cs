using System;
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
			return getPrefabPathFromAttribute( obj.GetType() );
		}
		public string getPrefabPathFromAttribute( Type type ){
			var attrs = type.GetCustomAttributes( typeof( Binding.PrefabAttribute ), true );
			if( !attrs.Any() ){
				throw new Exception( "PrefabAttribute is not found!!" );
			}
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