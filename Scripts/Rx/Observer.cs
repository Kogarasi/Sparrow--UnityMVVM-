using System;

namespace Sparrow.Rx {
	public class Observer<T>: Disposable  {
		Subject<T> parent;
		Action<T> callback;
		bool isUnsubscribed = false;

		public Observer( Action<T> callback, Subject<T> parent ){
			this.parent = parent;
			this.callback = callback;
		}

		public void publish( T value ){
			this.callback(value);
		}

		public void unsubscribe(){
			if(!isUnsubscribed){
				isUnsubscribed = true;
				parent.unsubscribe(this);
			}
		}

		public override void dispose(){
			unsubscribe();
		}
	}
}