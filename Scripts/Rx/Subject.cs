using System;
using System.Linq;
using System.Collections.Generic;

namespace Sparrow.Rx{
	public class Subject<T> {
		private List<Observer<T>> observers = new List<Observer<T>>();

		public virtual Observer<T> subscribe( Action<T> callback ){
			var observer = new Observer<T>( callback, this );
			observers.Add(observer);
			return observer;
		}

		public void unsubscribe( Observer<T> observer ){
			this.observers.Remove(observer);
		}

		public virtual void publish( T value ){
			observers.ForEach( observer => observer.publish(value) );
		}
	}
}
