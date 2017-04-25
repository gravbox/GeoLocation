//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Linq.Expressions;
using System.Data.Linq.Mapping;
using System.Collections;
using System.Collections.Generic;
using Gravitybox.LocationService.EFDAL;

namespace Gravitybox.LocationService.EFDAL
{
	#region StateQuery

	/// <summary>
	/// This is a helper object for running LINQ queries on the State collection.
	/// </summary>
	[Serializable]
	[Table(Name = "State")]
	[System.CodeDom.Compiler.GeneratedCode("nHydrateModelGenerator", "6.0.0")]
	public partial class StateQuery : IBusinessObjectLINQQuery
	{
		#region Properties
		/// <summary>
		/// (Maps to the 'State.Abbr' database field)
		/// </summary>
		[Column(Name = "Abbr", DbType = "VarChar (2)", CanBeNull = false, IsPrimaryKey = false)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual string Abbr { get; set; }
		/// <summary>
		/// (Maps to the 'State.Description' database field)
		/// </summary>
		[Column(Name = "Description", DbType = "VarChar (1000)", CanBeNull = true, IsPrimaryKey = false)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual string Description { get; set; }
		/// <summary>
		/// (Maps to the 'State.Name' database field)
		/// </summary>
		[Column(Name = "Name", DbType = "VarChar (128)", CanBeNull = false, IsPrimaryKey = false)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual string Name { get; set; }
		/// <summary>
		/// (Maps to the 'State.StateId' database field)
		/// </summary>
		[Column(Name = "StateId", DbType = "Int", CanBeNull = false, IsPrimaryKey = true)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual int StateId { get; set; }
		/// <summary>
		/// The date of creation
		/// </summary>
		[Column(Name = "CreatedDate", DbType = "DateTime", CanBeNull = true)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual DateTime? CreatedDate { get; set; }
		/// <summary>
		/// The name of the creating entity
		/// </summary>
		[Column(Name = "CreatedBy", DbType = "VarChar(100)", CanBeNull = true)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual string CreatedBy { get; set; }
		/// <summary>
		/// The date of last modification
		/// </summary>
		[Column(Name = "ModifiedDate", DbType = "DateTime", CanBeNull = true)]
		public virtual DateTime? ModifiedDate { get; set; }
		/// <summary>
		/// The name of the last modifing entity
		/// </summary>
		[Column(Name = "ModifiedBy", DbType = "VarChar(100)", CanBeNull = true)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual string ModifiedBy { get; set; }
		/// <summary>
		/// This is an internal field and is not to be used.
		/// </summary>
		[Column(Name = "TimeStamp", DbType = "Binary", CanBeNull = false)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual byte[] TimeStamp { get; set; }

		#endregion

	}

	#endregion

	#region ZipQuery

	/// <summary>
	/// This is a helper object for running LINQ queries on the Zip collection.
	/// </summary>
	[Serializable]
	[Table(Name = "Zip")]
	[System.CodeDom.Compiler.GeneratedCode("nHydrateModelGenerator", "6.0.0")]
	public partial class ZipQuery : IBusinessObjectLINQQuery
	{
		#region Properties
		/// <summary>
		/// (Maps to the 'Zip.City' database field)
		/// </summary>
		[Column(Name = "City", DbType = "VarChar (50)", CanBeNull = false, IsPrimaryKey = false)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual string City { get; set; }
		/// <summary>
		/// (Maps to the 'Zip.Latitude' database field)
		/// </summary>
		[Column(Name = "Latitude", DbType = "Float", CanBeNull = true, IsPrimaryKey = false)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual double? Latitude { get; set; }
		/// <summary>
		/// (Maps to the 'Zip.Longitude' database field)
		/// </summary>
		[Column(Name = "Longitude", DbType = "Float", CanBeNull = true, IsPrimaryKey = false)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual double? Longitude { get; set; }
		/// <summary>
		/// (Maps to the 'Zip.Name' database field)
		/// </summary>
		[Column(Name = "Name", DbType = "VarChar (10)", CanBeNull = false, IsPrimaryKey = false)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual string Name { get; set; }
		/// <summary>
		/// (Maps to the 'Zip.Population' database field)
		/// </summary>
		[Column(Name = "Population", DbType = "Int", CanBeNull = true, IsPrimaryKey = false)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual int? Population { get; set; }
		/// <summary>
		/// (Maps to the 'Zip.State' database field)
		/// </summary>
		[Column(Name = "State", DbType = "VarChar (50)", CanBeNull = false, IsPrimaryKey = false)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual string State { get; set; }
		/// <summary>
		/// (Maps to the 'Zip.ZipId' database field)
		/// </summary>
		[Column(Name = "ZipId", DbType = "Int", CanBeNull = false, IsPrimaryKey = true)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual int ZipId { get; set; }
		/// <summary>
		/// The date of creation
		/// </summary>
		[Column(Name = "CreatedDate", DbType = "DateTime", CanBeNull = true)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual DateTime? CreatedDate { get; set; }
		/// <summary>
		/// The name of the creating entity
		/// </summary>
		[Column(Name = "CreatedBy", DbType = "VarChar(100)", CanBeNull = true)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual string CreatedBy { get; set; }
		/// <summary>
		/// The date of last modification
		/// </summary>
		[Column(Name = "ModifiedDate", DbType = "DateTime", CanBeNull = true)]
		public virtual DateTime? ModifiedDate { get; set; }
		/// <summary>
		/// The name of the last modifing entity
		/// </summary>
		[Column(Name = "ModifiedBy", DbType = "VarChar(100)", CanBeNull = true)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual string ModifiedBy { get; set; }
		/// <summary>
		/// This is an internal field and is not to be used.
		/// </summary>
		[Column(Name = "TimeStamp", DbType = "Binary", CanBeNull = false)]
		[System.Diagnostics.DebuggerNonUserCode()]
		public virtual byte[] TimeStamp { get; set; }

		#endregion

	}

	#endregion

}
