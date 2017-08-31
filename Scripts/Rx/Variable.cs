using System;

namespace Sparrow.Rx{
	public class Variable<T>: Subject<T> {
		private T _value;
		public T value {
			get {
				return _value;
			}
			set {
				_value = value;
				publish( _value );
			}
		}

		public Variable( T value ){
			this.value = value;
		}

		public override Observer<T> subscribe( Action<T> callback ){
			var observer = base.subscribe(callback);
			observer.publish( _value );
			return observer;
		}
	}
}