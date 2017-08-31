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

		public override void Dispose(){
			if(!isDisposed){
				base.Dispose();

				_instance = null;
			}
		}
	}
}