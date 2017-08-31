using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

using Sparrow.Binding;
using Sparrow.Interface;

namespace Sparrow {
	public class Scene<T>: MonoBehaviour where T: Scene<T> {
		List<ModelBase> models = new List<ModelBase>();
		List<Updatable> updatables = new List<Updatable>();

		public void Awake(){
			manageModels();
		}

		public void Start(){
			injectViews();
		}

		public void Update(){
			updatables.ForEach( x => x.update() );
		}

		public void OnDestroy(){
			cleanModels();
		}

		void manageModels(){
			var attrs = (typeof(T).GetCustomAttributes( typeof(ManageModelAttribute), true ) as ManageModelAttribute[] ).ToList();
			attrs.ForEach( (attr)=>{

				var propertyInfo = attr.type.GetProperty( "instance", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy );
				var model = propertyInfo.GetValue( null, null ) as ModelBase;
				models.Add(model);

				if( model is Updatable ){
					updatables.Add( model as Updatable );
				}
			});
		}

		void injectViews(){
			var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
			var fields = typeof(T).GetFields(flags).Where( field => typeof(View).IsAssignableFrom(field.FieldType)).ToList();
			
			fields.ForEach((field)=>{
				var attr = Attribute.GetCustomAttribute(field, typeof(InjectViewAttribute));
				if( attr != null ){
					var objectName = (attr as InjectViewAttribute).objectName;

					var views = FindObjectsOfType(field.FieldType);
					var view = views.Where( v => v.name == objectName ).FirstOrDefault();

					if(!view){
						throw new Exception("Not found GameObject : " +objectName );
					}

					field.SetValue( this, view );
				}
			});
		}

		void cleanModels(){
			updatables.Clear();
			
			models.ForEach( x=> x.Dispose() );
			models.Clear();
		}
	}
}