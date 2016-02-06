﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Airliners.net.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Airliners.net")]
	public partial class AirlinersDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertFoto(Foto instance);
    partial void UpdateFoto(Foto instance);
    partial void DeleteFoto(Foto instance);
    partial void InsertUsuario(Usuario instance);
    partial void UpdateUsuario(Usuario instance);
    partial void DeleteUsuario(Usuario instance);
    #endregion
		
		public AirlinersDBDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["Airliners_netConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public AirlinersDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AirlinersDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AirlinersDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AirlinersDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Album> Albums
		{
			get
			{
				return this.GetTable<Album>();
			}
		}
		
		public System.Data.Linq.Table<Foto> Fotos
		{
			get
			{
				return this.GetTable<Foto>();
			}
		}
		
		public System.Data.Linq.Table<Usuario> Usuarios
		{
			get
			{
				return this.GetTable<Usuario>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Album")]
	public partial class Album
	{
		
		private string _Nombre;
		
		private string _Nombre_Foto;
		
		private string _Nombre_Usu;
		
		public Album()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this._Nombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre_Foto", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Nombre_Foto
		{
			get
			{
				return this._Nombre_Foto;
			}
			set
			{
				if ((this._Nombre_Foto != value))
				{
					this._Nombre_Foto = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre_Usu", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Nombre_Usu
		{
			get
			{
				return this._Nombre_Usu;
			}
			set
			{
				if ((this._Nombre_Usu != value))
				{
					this._Nombre_Usu = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Foto")]
	public partial class Foto : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Aerolinea;
		
		private string _Avion;
		
		private string _Lugar;
		
		private System.DateTime _Fecha;
		
		private string _Notas;
		
		private string _Fotografo;
		
		private string _Nombre;
		
		private EntityRef<Usuario> _Usuario;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAerolineaChanging(string value);
    partial void OnAerolineaChanged();
    partial void OnAvionChanging(string value);
    partial void OnAvionChanged();
    partial void OnLugarChanging(string value);
    partial void OnLugarChanged();
    partial void OnFechaChanging(System.DateTime value);
    partial void OnFechaChanged();
    partial void OnNotasChanging(string value);
    partial void OnNotasChanged();
    partial void OnFotografoChanging(string value);
    partial void OnFotografoChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    #endregion
		
		public Foto()
		{
			this._Usuario = default(EntityRef<Usuario>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Aerolinea", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Aerolinea
		{
			get
			{
				return this._Aerolinea;
			}
			set
			{
				if ((this._Aerolinea != value))
				{
					this.OnAerolineaChanging(value);
					this.SendPropertyChanging();
					this._Aerolinea = value;
					this.SendPropertyChanged("Aerolinea");
					this.OnAerolineaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Avion", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Avion
		{
			get
			{
				return this._Avion;
			}
			set
			{
				if ((this._Avion != value))
				{
					this.OnAvionChanging(value);
					this.SendPropertyChanging();
					this._Avion = value;
					this.SendPropertyChanged("Avion");
					this.OnAvionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Lugar", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Lugar
		{
			get
			{
				return this._Lugar;
			}
			set
			{
				if ((this._Lugar != value))
				{
					this.OnLugarChanging(value);
					this.SendPropertyChanging();
					this._Lugar = value;
					this.SendPropertyChanged("Lugar");
					this.OnLugarChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fecha", DbType="Date NOT NULL")]
		public System.DateTime Fecha
		{
			get
			{
				return this._Fecha;
			}
			set
			{
				if ((this._Fecha != value))
				{
					this.OnFechaChanging(value);
					this.SendPropertyChanging();
					this._Fecha = value;
					this.SendPropertyChanged("Fecha");
					this.OnFechaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Notas", DbType="VarChar(MAX)")]
		public string Notas
		{
			get
			{
				return this._Notas;
			}
			set
			{
				if ((this._Notas != value))
				{
					this.OnNotasChanging(value);
					this.SendPropertyChanging();
					this._Notas = value;
					this.SendPropertyChanged("Notas");
					this.OnNotasChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fotografo", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Fotografo
		{
			get
			{
				return this._Fotografo;
			}
			set
			{
				if ((this._Fotografo != value))
				{
					if (this._Usuario.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnFotografoChanging(value);
					this.SendPropertyChanging();
					this._Fotografo = value;
					this.SendPropertyChanged("Fotografo");
					this.OnFotografoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuario_Foto", Storage="_Usuario", ThisKey="Fotografo", OtherKey="Nombre", IsForeignKey=true)]
		public Usuario Usuario
		{
			get
			{
				return this._Usuario.Entity;
			}
			set
			{
				Usuario previousValue = this._Usuario.Entity;
				if (((previousValue != value) 
							|| (this._Usuario.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Usuario.Entity = null;
						previousValue.Fotos.Remove(this);
					}
					this._Usuario.Entity = value;
					if ((value != null))
					{
						value.Fotos.Add(this);
						this._Fotografo = value.Nombre;
					}
					else
					{
						this._Fotografo = default(string);
					}
					this.SendPropertyChanged("Usuario");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Usuario")]
	public partial class Usuario : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Nombre;
		
		private string _Email;
		
		private string _Sexo;
		
		private int _Edad;
		
		private string _Pais;
		
		private string _Alias;
		
		private string _Contraseña;
		
		private string _Ocupacion;
		
		private string _Hobbies;
		
		private string _Ciudad;
		
		private string _URLPersonal;
		
		private string _Otros;
		
		private EntitySet<Foto> _Fotos;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnSexoChanging(string value);
    partial void OnSexoChanged();
    partial void OnEdadChanging(int value);
    partial void OnEdadChanged();
    partial void OnPaisChanging(string value);
    partial void OnPaisChanged();
    partial void OnAliasChanging(string value);
    partial void OnAliasChanged();
    partial void OnContraseñaChanging(string value);
    partial void OnContraseñaChanged();
    partial void OnOcupacionChanging(string value);
    partial void OnOcupacionChanged();
    partial void OnHobbiesChanging(string value);
    partial void OnHobbiesChanged();
    partial void OnCiudadChanging(string value);
    partial void OnCiudadChanged();
    partial void OnURLPersonalChanging(string value);
    partial void OnURLPersonalChanged();
    partial void OnOtrosChanging(string value);
    partial void OnOtrosChanged();
    #endregion
		
		public Usuario()
		{
			this._Fotos = new EntitySet<Foto>(new Action<Foto>(this.attach_Fotos), new Action<Foto>(this.detach_Fotos));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sexo", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Sexo
		{
			get
			{
				return this._Sexo;
			}
			set
			{
				if ((this._Sexo != value))
				{
					this.OnSexoChanging(value);
					this.SendPropertyChanging();
					this._Sexo = value;
					this.SendPropertyChanged("Sexo");
					this.OnSexoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Edad", DbType="Int NOT NULL")]
		public int Edad
		{
			get
			{
				return this._Edad;
			}
			set
			{
				if ((this._Edad != value))
				{
					this.OnEdadChanging(value);
					this.SendPropertyChanging();
					this._Edad = value;
					this.SendPropertyChanged("Edad");
					this.OnEdadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pais", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Pais
		{
			get
			{
				return this._Pais;
			}
			set
			{
				if ((this._Pais != value))
				{
					this.OnPaisChanging(value);
					this.SendPropertyChanging();
					this._Pais = value;
					this.SendPropertyChanged("Pais");
					this.OnPaisChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Alias", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Alias
		{
			get
			{
				return this._Alias;
			}
			set
			{
				if ((this._Alias != value))
				{
					this.OnAliasChanging(value);
					this.SendPropertyChanging();
					this._Alias = value;
					this.SendPropertyChanged("Alias");
					this.OnAliasChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Contraseña", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string Contraseña
		{
			get
			{
				return this._Contraseña;
			}
			set
			{
				if ((this._Contraseña != value))
				{
					this.OnContraseñaChanging(value);
					this.SendPropertyChanging();
					this._Contraseña = value;
					this.SendPropertyChanged("Contraseña");
					this.OnContraseñaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ocupacion", DbType="VarChar(50)")]
		public string Ocupacion
		{
			get
			{
				return this._Ocupacion;
			}
			set
			{
				if ((this._Ocupacion != value))
				{
					this.OnOcupacionChanging(value);
					this.SendPropertyChanging();
					this._Ocupacion = value;
					this.SendPropertyChanged("Ocupacion");
					this.OnOcupacionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hobbies", DbType="VarChar(MAX)")]
		public string Hobbies
		{
			get
			{
				return this._Hobbies;
			}
			set
			{
				if ((this._Hobbies != value))
				{
					this.OnHobbiesChanging(value);
					this.SendPropertyChanging();
					this._Hobbies = value;
					this.SendPropertyChanged("Hobbies");
					this.OnHobbiesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ciudad", DbType="VarChar(50)")]
		public string Ciudad
		{
			get
			{
				return this._Ciudad;
			}
			set
			{
				if ((this._Ciudad != value))
				{
					this.OnCiudadChanging(value);
					this.SendPropertyChanging();
					this._Ciudad = value;
					this.SendPropertyChanged("Ciudad");
					this.OnCiudadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_URLPersonal", DbType="VarChar(50)")]
		public string URLPersonal
		{
			get
			{
				return this._URLPersonal;
			}
			set
			{
				if ((this._URLPersonal != value))
				{
					this.OnURLPersonalChanging(value);
					this.SendPropertyChanging();
					this._URLPersonal = value;
					this.SendPropertyChanged("URLPersonal");
					this.OnURLPersonalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Otros", DbType="VarChar(50)")]
		public string Otros
		{
			get
			{
				return this._Otros;
			}
			set
			{
				if ((this._Otros != value))
				{
					this.OnOtrosChanging(value);
					this.SendPropertyChanging();
					this._Otros = value;
					this.SendPropertyChanged("Otros");
					this.OnOtrosChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuario_Foto", Storage="_Fotos", ThisKey="Nombre", OtherKey="Fotografo")]
		public EntitySet<Foto> Fotos
		{
			get
			{
				return this._Fotos;
			}
			set
			{
				this._Fotos.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Fotos(Foto entity)
		{
			this.SendPropertyChanging();
			entity.Usuario = this;
		}
		
		private void detach_Fotos(Foto entity)
		{
			this.SendPropertyChanging();
			entity.Usuario = null;
		}
	}
}
#pragma warning restore 1591
