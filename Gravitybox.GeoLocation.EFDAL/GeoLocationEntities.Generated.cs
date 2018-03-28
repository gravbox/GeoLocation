//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#pragma warning disable 612
using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.ModelConfiguration;
using Gravitybox.GeoLocation.EFDAL.Entity;
using System.Data.Entity.Core.Objects;

namespace Gravitybox.GeoLocation.EFDAL
{
	#region EntityMappingConstants Enumeration

	/// <summary>
	/// A map for all entity types in this library
	/// </summary>
	public enum EntityMappingConstants
	{
		/// <summary>
		/// A mapping for the the CanadaPostalCode entity
		/// </summary>
		CanadaPostalCode,
		/// <summary>
		/// A mapping for the the City entity
		/// </summary>
		City,
		/// <summary>
		/// A mapping for the the State entity
		/// </summary>
		State,
		/// <summary>
		/// A mapping for the the Zip entity
		/// </summary>
		Zip,
	}

	#endregion

	#region Entity Context

	/// <summary>
	/// The object context for the schema tied to this generated model.
	/// </summary>
	public partial class GeoLocationEntities : System.Data.Entity.DbContext, Gravitybox.GeoLocation.EFDAL.IGeoLocationEntities, IContext
	{
		static GeoLocationEntities()
		{
			System.Data.Entity.Infrastructure.Interception.DbInterception.Add(new DbInterceptor());
		}

		/// <summary />
		public static Action<string> QueryLogger { get; set; }

		/// <summary>
		/// A unique key for this object instance
		/// </summary>
		public Guid InstanceKey { get; private set; }

		/// <summary />
		protected override void Dispose(bool disposing)
		{
			QueryPreCache.RemoveAll(InstanceKey);
			base.Dispose(disposing);
		}

		/// <summary>
		/// The audit modifier used to mark database edits
		/// </summary>
		protected ContextStartup _contextStartup = new ContextStartup(null);

		private static Dictionary<string, SequentialIdGenerator> _sequentialIdGeneratorCache = new Dictionary<string, SequentialIdGenerator>();
		private static object _seqCacheLock = new object();

		private const string _version = "0.0.0.3.20";
		private const string _modelKey = "792c16d4-9353-4f34-bf2b-4c66aa688643";

		/// <summary />
		[field:NonSerialized]
		public event EventHandler<Gravitybox.GeoLocation.EFDAL.EventArguments.EntityListEventArgs> BeforeSaveModifiedEntity;
		/// <summary />
		protected virtual void OnBeforeSaveModifiedEntity(Gravitybox.GeoLocation.EFDAL.EventArguments.EntityListEventArgs e)
		{
			if(BeforeSaveModifiedEntity != null)
			{
				BeforeSaveModifiedEntity(this, e);
			}
		}

		/// <summary />
		[field:NonSerialized]
		public event EventHandler<Gravitybox.GeoLocation.EFDAL.EventArguments.EntityListEventArgs> BeforeSaveAddedEntity;
		/// <summary />
		protected virtual void OnBeforeSaveAddedEntity(Gravitybox.GeoLocation.EFDAL.EventArguments.EntityListEventArgs e)
		{
			if(BeforeSaveAddedEntity != null)
			{
				BeforeSaveAddedEntity(this, e);
			}
		}

		/// <summary />
		[field:NonSerialized]
		public event EventHandler<Gravitybox.GeoLocation.EFDAL.EventArguments.EntityListEventArgs> AfterSaveModifiedEntity;
		/// <summary />
		protected virtual void OnAfterSaveModifiedEntity(Gravitybox.GeoLocation.EFDAL.EventArguments.EntityListEventArgs e)
		{
			if(AfterSaveModifiedEntity != null)
			{
				AfterSaveModifiedEntity(this, e);
			}
		}

		/// <summary />
		[field:NonSerialized]
		public event EventHandler<Gravitybox.GeoLocation.EFDAL.EventArguments.EntityListEventArgs> AfterSaveAddedEntity;
		/// <summary />
		protected virtual void OnAfterSaveAddedEntity(Gravitybox.GeoLocation.EFDAL.EventArguments.EntityListEventArgs e)
		{
			if(AfterSaveAddedEntity != null)
			{
				AfterSaveAddedEntity(this, e);
			}
		}

		#region Constructors

		private void ResetContextStartup()
		{
			try
			{
				var frame = new System.Diagnostics.StackFrame(2, true);
				var method = frame.GetMethod();
				int lineNumber = frame.GetFileLineNumber();
				_contextStartup.DebugInfo = method.DeclaringType.ToString() + "." + method.Name + ":" + lineNumber;
			}
			catch { }
		}

		/// <summary>
		/// Initializes a new GeoLocationEntities object using the connection string found in the 'GeoLocationEntities' section of the application configuration file.
		/// </summary>
		public GeoLocationEntities() :
			base(Util.ConvertNormalCS2EFFromConfig("name=GeoLocationEntities"))
		{
			InstanceKey = Guid.NewGuid();
			_contextStartup = new EFDAL.ContextStartup(null, true);
			ResetContextStartup();
			try
			{
				var builder = new System.Data.Odbc.OdbcConnectionStringBuilder(Util.StripEFCS2Normal(this.Database.Connection.ConnectionString));
				var timeoutValue = "30";
				if (builder.ContainsKey("connect timeout"))
					timeoutValue = (string) builder["connect timeout"];
				else if (builder.ContainsKey("connection timeout"))
					timeoutValue = (string) builder["connection timeout"];
				var v = Convert.ToInt32(timeoutValue);
				if (v > 0)
					this.CommandTimeout = v;
			}
			catch { }
			this.OnContextCreated();
		}

		/// <summary>
		/// Initialize a new GeoLocationEntities object with an audit modifier.
		/// </summary>
		public GeoLocationEntities(ContextStartup contextStartup) :
			base(Util.ConvertNormalCS2EFFromConfig("name=GeoLocationEntities", contextStartup))
		{
			InstanceKey = Guid.NewGuid();
			_contextStartup = contextStartup;
			ResetContextStartup();
			this.ContextOptions.LazyLoadingEnabled = contextStartup.AllowLazyLoading;
			this.CommandTimeout = contextStartup.CommandTimeout;
			this.OnContextCreated();
		}

		/// <summary>
		/// Initialize a new GeoLocationEntities object with an audit modifier.
		/// </summary>
		public GeoLocationEntities(ContextStartup contextStartup, string connectionString) :
			base(Util.ConvertNormalCS2EF(connectionString, contextStartup))
		{
			InstanceKey = Guid.NewGuid();
			_contextStartup = contextStartup;
			ResetContextStartup();
			this.ContextOptions.LazyLoadingEnabled = contextStartup.AllowLazyLoading;
			this.CommandTimeout = contextStartup.CommandTimeout;
			this.OnContextCreated();
		}

		/// <summary>
		/// Initialize a new GeoLocationEntities object.
		/// </summary>
		public GeoLocationEntities(string connectionString) :
			base(Util.ConvertNormalCS2EF(connectionString))
		{
			InstanceKey = Guid.NewGuid();
			_contextStartup = new EFDAL.ContextStartup(null, true);
			ResetContextStartup();
			try
			{
				var builder = new System.Data.Odbc.OdbcConnectionStringBuilder(Util.StripEFCS2Normal(this.Database.Connection.ConnectionString));
				var timeoutValue = "30";
				if (builder.ContainsKey("connect timeout"))
					timeoutValue = (string) builder["connect timeout"];
				else if (builder.ContainsKey("connection timeout"))
					timeoutValue = (string) builder["connection timeout"];
				var v = Convert.ToInt32(timeoutValue);
				if (v > 0)
					this.CommandTimeout = v;
			}
			catch { }
			this.OnContextCreated();
		}

		#endregion

		partial void OnContextCreated();
		partial void OnBeforeSaveChanges(ref bool cancel);
		partial void OnAfterSaveChanges();

		/// <summary>
		/// Model creation event
		/// </summary>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
			Database.SetInitializer(new CustomDatabaseInitializer<GeoLocationEntities>());

			//Manually set the entities that have a security function because their DbSet<> is protected and not set

			#region Hierarchy Mapping
			#endregion

			#region Map Tables
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.CanadaPostalCode>().ToTable("CanadaPostalCode", "dbo");
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.City>().ToTable("City", "dbo");
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.State>().ToTable("State", "dbo");
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.Zip>().ToTable("Zip", "dbo");
			#endregion

			#region Setup Fields

			//Field setup for CanadaPostalCode entity
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.CanadaPostalCode>().Property(d => d.City).IsRequired().HasMaxLength(100).HasColumnType("VARCHAR");
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.CanadaPostalCode>().Property(d => d.Latitude).IsOptional();
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.CanadaPostalCode>().Property(d => d.Longitude).IsOptional();
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.CanadaPostalCode>().Property(d => d.PostalCode).IsRequired().HasMaxLength(10).HasColumnType("VARCHAR");
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.CanadaPostalCode>().Property(d => d.RowId).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

			//Field setup for City entity
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.City>().Property(d => d.CityId).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.City>().Property(d => d.Name).IsOptional().HasMaxLength(100).HasColumnType("VARCHAR");
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.City>().Property(d => d.Population).IsOptional();
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.City>().Property(d => d.State).IsOptional().HasMaxLength(50).HasColumnType("VARCHAR");
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.City>().Property(d => d.TimeStamp).IsConcurrencyToken(true);

			//Field setup for State entity
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.State>().Property(d => d.Abbr).IsRequired().HasMaxLength(2).HasColumnType("VARCHAR");
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.State>().Property(d => d.Description).IsOptional().HasMaxLength(1000).HasColumnType("VARCHAR");
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.State>().Property(d => d.Name).IsRequired().HasMaxLength(128).HasColumnType("VARCHAR");
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.State>().Property(d => d.StateId).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.State>().Property(d => d.TimeStamp).IsConcurrencyToken(true);

			//Field setup for Zip entity
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.Zip>().Property(d => d.City).IsRequired().HasMaxLength(50).HasColumnType("VARCHAR");
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.Zip>().Property(d => d.Latitude).IsOptional();
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.Zip>().Property(d => d.Longitude).IsOptional();
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.Zip>().Property(d => d.Name).IsRequired().HasMaxLength(10).HasColumnType("VARCHAR");
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.Zip>().Property(d => d.Population).IsOptional();
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.Zip>().Property(d => d.State).IsRequired().HasMaxLength(50).HasColumnType("VARCHAR");
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.Zip>().Property(d => d.ZipId).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.Zip>().Property(d => d.TimeStamp).IsConcurrencyToken(true);

			#endregion

			#region Ignore Enum Properties


			#endregion

			#region Relations

			#endregion

			#region Functions


			#endregion

			#region Primary Keys

			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.CanadaPostalCode>().HasKey(x => new { x.RowId });
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.City>().HasKey(x => new { x.CityId });
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.State>().HasKey(x => new { x.StateId });
			modelBuilder.Entity<Gravitybox.GeoLocation.EFDAL.Entity.Zip>().HasKey(x => new { x.ZipId });

			#endregion

		}

		/// <summary />
		public static void ResetSequentialGuid(EntityMappingConstants entity, string key, Guid seed)
		{
			if (string.IsNullOrEmpty(key))
				throw new Exception("Invalid key");

			lock (_seqCacheLock)
			{
				var k = entity.ToString() + "|" + key;
				if (!_sequentialIdGeneratorCache.ContainsKey(k))
					_sequentialIdGeneratorCache.Add(k, new SequentialIdGenerator(seed));
				else
					_sequentialIdGeneratorCache[k].LastValue = seed;
			}

		}

		/// <summary />
		public static Guid GetNextSequentialGuid(EntityMappingConstants entity, string key)
		{
			if (string.IsNullOrEmpty(key))
				throw new Exception("Invalid key");

			lock (_seqCacheLock)
			{
				var k = entity.ToString() + "|" + key;
				if (!_sequentialIdGeneratorCache.ContainsKey(k))
					ResetSequentialGuid(entity, key, Guid.NewGuid());
				return _sequentialIdGeneratorCache[k].NewId();
			}
		}

		/// <summary>
		/// Persists all updates to the data source and resets change tracking in the object context.
		/// </summary>
		/// <returns>The number of objects in an System.Data.Entity.EntityState.Added, System.Data.Entity.EntityState.Modified, or System.Data.Entity.EntityState.Deleted state when System.Data.Objects.ObjectContext.SaveChanges() was called.</returns>
		public override int SaveChanges()
		{
			var cancel = false;
			OnBeforeSaveChanges(ref cancel);
			if (cancel) return 0;

			//This must be called to truly see all Added/Updated Entities in the ObjectStateManager!!!
			//Items added to context work fine, but children added to parent objects do not i.e. 'ParentObject.ChildItems.Add(newChild)'
			this.ChangeTracker.Entries().Any();

			//Get the added list
			var addedList = this.ObjectContext.ObjectStateManager.GetObjectStateEntries(System.Data.Entity.EntityState.Added);
			var markedTime = System.DateTime.Now;
			//Process added list
			foreach (var item in addedList)
			{
				var entity = item.Entity as IAuditable;
				if (entity != null)
				{
					var audit = entity as IAuditableSet;
					if (audit != null && entity.IsModifyAuditImplemented && entity.ModifiedBy != this.ContextStartup.Modifer)
					{
						if (audit != null) audit.ResetCreatedBy(this.ContextStartup.Modifer);
						if (audit != null) audit.ResetModifiedBy(this.ContextStartup.Modifer);
					}
					if (audit != null)
					{
						audit.CreatedDate = markedTime;
						audit.ModifiedDate = markedTime;
					}
				}
			}
			this.OnBeforeSaveAddedEntity(new EventArguments.EntityListEventArgs { List = addedList });

			//Process modified list
			var modifiedList = this.ObjectContext.ObjectStateManager.GetObjectStateEntries(System.Data.Entity.EntityState.Modified);
			foreach (var item in modifiedList)
			{
				var entity = item.Entity as IAuditable;
				if (entity != null)
				{
					var audit = entity as IAuditableSet;
					if (entity.IsModifyAuditImplemented && entity.ModifiedBy != this.ContextStartup.Modifer)
					{
						if (audit != null) audit.ResetModifiedBy(this.ContextStartup.Modifer);
					}
					audit.ModifiedDate = markedTime;
				}
			}
			this.OnBeforeSaveModifiedEntity(new EventArguments.EntityListEventArgs { List = modifiedList });

			var retval = 0;
			DbContextTransaction customTrans = null;
			try
			{
				_paramList.Clear();
				if (base.Database.CurrentTransaction == null)
					customTrans = base.Database.BeginTransaction();
				retval += QueryPreCache.ExecuteDeletes(this);
				retval += base.SaveChanges();
				retval += QueryPreCache.ExecuteUpdates(this);
				if (customTrans != null)
					customTrans.Commit();
			}
			catch (System.Data.Entity.Validation.DbEntityValidationException ex)
			{
				var sb = new System.Text.StringBuilder();
				foreach (var error in ex.EntityValidationErrors)
				{
					foreach (var validationError in error.ValidationErrors)
					{
						sb.AppendLine(validationError.PropertyName + ": " + validationError.ErrorMessage);
					}
				}
				throw new System.Data.Entity.Validation.DbEntityValidationException(sb.ToString(), ex.EntityValidationErrors);
			}
			catch
			{
				throw;
			}
			finally
			{
				if (customTrans != null)
					customTrans.Dispose();
			}
			this.OnAfterSaveAddedEntity(new EventArguments.EntityListEventArgs { List = addedList });
			this.OnAfterSaveModifiedEntity(new EventArguments.EntityListEventArgs { List = modifiedList });
			OnAfterSaveChanges();
			return retval;
		}

		#region Entity Sets

		/// <summary>
		/// Entity set for CanadaPostalCode
		/// </summary>
		public virtual DbSet<Gravitybox.GeoLocation.EFDAL.Entity.CanadaPostalCode> CanadaPostalCode { get; set; }

		/// <summary>
		/// Entity set for City
		/// </summary>
		public virtual DbSet<Gravitybox.GeoLocation.EFDAL.Entity.City> City { get; set; }

		/// <summary>
		/// Entity set for State
		/// </summary>
		public virtual DbSet<Gravitybox.GeoLocation.EFDAL.Entity.State> State { get; set; }

		/// <summary>
		/// Entity set for Zip
		/// </summary>
		public virtual DbSet<Gravitybox.GeoLocation.EFDAL.Entity.Zip> Zip { get; set; }

		#endregion

		/// <summary>
		/// The global settings of this context
		/// </summary>
		public virtual ContextStartup ContextStartup
		{
			get { return _contextStartup; }
		}

		/// <summary />
		public virtual System.Data.Entity.Core.Objects.ObjectContextOptions ContextOptions
		{
			get { return this.ObjectContext.ContextOptions; }
		}

		/// <summary>
		/// Determines the version of the model that created this library.
		/// </summary>
		public virtual string Version
		{
			get { return _version; }
		}

		/// <summary>
		/// Determines the key of the model that created this library.
		/// </summary>
		public virtual string ModelKey
		{
			get { return _modelKey; }
		}

		/// <summary>
		/// Determines if the API matches the database connection
		/// </summary>
		public virtual bool IsValidConnection()
		{
			return IsValidConnection(GetConnectionString(), true);
		}

		/// <summary>
		/// Determines if the API matches the database connection
		/// </summary>
		public virtual bool IsValidConnection(bool checkVersion)
		{
			return IsValidConnection(GetConnectionString(), checkVersion);
		}

		/// <summary>
		/// Determines if the API matches the database connection
		/// </summary>
		/// <param name="checkVersion">Determines if the check also includes the exact version of the model</param>
		/// <param name="connectionString">Determines the connection string to use when connecting to the database</param>
		/// <returns></returns>
		public virtual bool IsValidConnection(string connectionString, bool checkVersion = true)
		{
			if (string.IsNullOrEmpty(connectionString))
				return false;

			//Get current version
			var version = GetDBVersion(connectionString);

			//If there is any version then the ModelKey was found, if not found then the database does not contain this model
			if (string.IsNullOrEmpty(version))
				return false;

			if (checkVersion)
			{
				if (version != this.Version)
					return false;
			}

			return true;
		}

		/// <summary>
		/// Retrieves the latest database version for the current model
		/// </summary>
		public string GetDBVersion(string connectionString = null)
		{
			try
			{
				using (var conn = new System.Data.SqlClient.SqlConnection())
				{
					if (string.IsNullOrEmpty(connectionString))
						connectionString = this.ConnectionString;
					conn.ConnectionString = connectionString;
					conn.Open();

					var da = new SqlDataAdapter("select * from sys.tables where name = '__nhydrateschema'", conn);
					var ds = new DataSet();
					da.Fill(ds);
					if (ds.Tables[0].Rows.Count > 0)
					{
						da = new SqlDataAdapter("SELECT * FROM [__nhydrateschema] where [ModelKey] = '" + this.ModelKey + "'", conn);
						ds = new DataSet();
						da.Fill(ds);
						var t = ds.Tables[0];
						if (t.Rows.Count > 0)
						{
							return (string) t.Rows[0]["dbVersion"];
						}
					}
					return string.Empty;
				}
			}
			catch (Exception)
			{
				return string.Empty;
			}
		}

		#region AddItem Methods

		/// <summary>
		/// Adds an entity of to the object context
		/// </summary>
		/// <param name="entity">The entity to add</param>
		public virtual Gravitybox.GeoLocation.EFDAL.IBusinessObject AddItem(Gravitybox.GeoLocation.EFDAL.IBusinessObject entity)
		{
			if (entity == null) throw new NullReferenceException();
			var audit = entity as Gravitybox.GeoLocation.EFDAL.IAuditableSet;
			if (audit != null)
			{
				audit.CreatedBy = _contextStartup.Modifer;
				audit.ModifiedBy = _contextStartup.Modifer;
			}
			if (false) { }
			else if (entity is Gravitybox.GeoLocation.EFDAL.Entity.CanadaPostalCode)
			{
				this.CanadaPostalCode.Add((Gravitybox.GeoLocation.EFDAL.Entity.CanadaPostalCode)entity);
			}
			else if (entity is Gravitybox.GeoLocation.EFDAL.Entity.City)
			{
				this.City.Add((Gravitybox.GeoLocation.EFDAL.Entity.City)entity);
			}
			else if (entity is Gravitybox.GeoLocation.EFDAL.Entity.State)
			{
				this.State.Add((Gravitybox.GeoLocation.EFDAL.Entity.State)entity);
			}
			else if (entity is Gravitybox.GeoLocation.EFDAL.Entity.Zip)
			{
				this.Zip.Add((Gravitybox.GeoLocation.EFDAL.Entity.Zip)entity);
			}
			return entity;
		}

		#endregion

		#region DeleteItem Methods

		/// <summary>
		/// Deletes an entity from the context
		/// </summary>
		/// <param name="entity">The entity to delete</param>
		public virtual void DeleteItem(IBusinessObject entity)
		{
			if (entity == null) return;
			else this.ObjectContext.DeleteObject(entity);
		}

		#endregion

		/// <summary>
		/// Returns the connection string used for this context object
		/// </summary>
		public string ConnectionString
		{
			get
			{
				try
				{
					if (this.Database.Connection != null && !string.IsNullOrEmpty(this.Database.Connection.ConnectionString))
					{
						return Util.StripEFCS2Normal(this.Database.Connection.ConnectionString);
					}
					else
					{
						return null;
					}
				}
				catch (Exception)
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Returns the globally configured connection string for this context type
		/// </summary>
		internal static string GetConnectionString()
		{
			try
			{
				var a = System.Configuration.ConfigurationManager.ConnectionStrings["GeoLocationEntities"];
				if (a != null)
				{
					var s = a.ConnectionString;
					var regEx = new System.Text.RegularExpressions.Regex("provider connection string\\s*=\\s*\"([^\"]*)");
					var m = regEx.Match(s);
					var connString = s;
					if (m != null && m.Groups.Count > 1)
					{
						connString = m.Groups[1].Value;
					}
					return connString;
				}
				else
				{
					throw new Exception("The connection string was not found.");
				}
			}
			catch (Exception)
			{
				throw new Exception("The connection string was not found.");
			}
		}

		#region IGeoLocation Members

		/// <summary />
		IQueryable<Gravitybox.GeoLocation.EFDAL.Entity.CanadaPostalCode> Gravitybox.GeoLocation.EFDAL.IGeoLocationEntities.CanadaPostalCode
		{
			get { return this.CanadaPostalCode.AsQueryable(); }
		}

		/// <summary />
		IQueryable<Gravitybox.GeoLocation.EFDAL.Entity.City> Gravitybox.GeoLocation.EFDAL.IGeoLocationEntities.City
		{
			get { return this.City.AsQueryable(); }
		}

		/// <summary />
		IQueryable<Gravitybox.GeoLocation.EFDAL.Entity.State> Gravitybox.GeoLocation.EFDAL.IGeoLocationEntities.State
		{
			get { return this.State.AsQueryable(); }
		}

		/// <summary />
		IQueryable<Gravitybox.GeoLocation.EFDAL.Entity.Zip> Gravitybox.GeoLocation.EFDAL.IGeoLocationEntities.Zip
		{
			get { return this.Zip.AsQueryable(); }
		}

		/// <summary />
		protected List<string> _paramList = new List<string>();
		#endregion

		#region IContext Interface

		Enum IContext.GetEntityFromField(Enum field)
		{
			return GetEntityFromField(field);
		}

		object IContext.GetMetaData(Enum entity)
		{
			return GetMetaData((EntityMappingConstants)entity);
		}

		System.Type IContext.GetFieldType(Enum field)
		{
			return this.GetFieldType(field);
		}

		#endregion

		#region GetEntityFromField

		/// <summary>
		/// Determines the entity from one of its fields
		/// </summary>
		public static EntityMappingConstants GetEntityFromField(Enum field)
		{
			if (field is Gravitybox.GeoLocation.EFDAL.Entity.CanadaPostalCode.FieldNameConstants) return Gravitybox.GeoLocation.EFDAL.EntityMappingConstants.CanadaPostalCode;
			if (field is Gravitybox.GeoLocation.EFDAL.Entity.City.FieldNameConstants) return Gravitybox.GeoLocation.EFDAL.EntityMappingConstants.City;
			if (field is Gravitybox.GeoLocation.EFDAL.Entity.State.FieldNameConstants) return Gravitybox.GeoLocation.EFDAL.EntityMappingConstants.State;
			if (field is Gravitybox.GeoLocation.EFDAL.Entity.Zip.FieldNameConstants) return Gravitybox.GeoLocation.EFDAL.EntityMappingConstants.Zip;
			throw new Exception("Unknown field type!");
		}

		#endregion

		#region GetMetaData

		/// <summary>
		/// Gets the meta data object for an entity
		/// </summary>
		public static Gravitybox.GeoLocation.EFDAL.IMetadata GetMetaData(Gravitybox.GeoLocation.EFDAL.EntityMappingConstants table)
		{
			switch (table)
			{
				case Gravitybox.GeoLocation.EFDAL.EntityMappingConstants.CanadaPostalCode: return new Gravitybox.GeoLocation.EFDAL.Entity.Metadata.CanadaPostalCodeMetadata();
				case Gravitybox.GeoLocation.EFDAL.EntityMappingConstants.City: return new Gravitybox.GeoLocation.EFDAL.Entity.Metadata.CityMetadata();
				case Gravitybox.GeoLocation.EFDAL.EntityMappingConstants.State: return new Gravitybox.GeoLocation.EFDAL.Entity.Metadata.StateMetadata();
				case Gravitybox.GeoLocation.EFDAL.EntityMappingConstants.Zip: return new Gravitybox.GeoLocation.EFDAL.Entity.Metadata.ZipMetadata();
			}
			throw new Exception("Entity not found!");
		}

		/// <summary />
		public static string GetTableName(Gravitybox.GeoLocation.EFDAL.EntityMappingConstants entity)
		{
			var item = GetMetaData(entity);
			if (item == null) return null;
			return item.GetTableName();
		}
		#endregion

		#region Interface Extras

		/// <summary>
		/// Reloads the context object from database
		/// </summary>
		public void ReloadItem(BaseEntity entity)
		{
			this.Entry(entity).Reload();
		}

		/// <summary>
		/// Detaches the the object from context
		/// </summary>
		public void DetachItem(BaseEntity entity)
		{
			this.ObjectContext.Detach(entity);
		}

		#endregion

		#region ObjectContext

		/// <summary>
		/// Gets the object context
		/// </summary>
		public System.Data.Entity.Core.Objects.ObjectContext ObjectContext
		{
			get
			{
				if (_objectContext == null)
					_objectContext = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)this).ObjectContext;
				return _objectContext;
			}
		}
		private System.Data.Entity.Core.Objects.ObjectContext _objectContext = null;

		/// <summary>
		/// Accepts all changes made to objects in the object context
		/// </summary>
		public void AcceptAllChanges()
		{
			this.ObjectContext.AcceptAllChanges();
		}

		/// <summary>
		/// Determines the timeout of the database connection
		/// </summary>
		public int? CommandTimeout
		{
			get { return this.Database.CommandTimeout; }
			set { this.Database.CommandTimeout = value; }
		}

		#endregion

	}
	#endregion

	internal class CustomDatabaseInitializer<TContext> : IDatabaseInitializer<TContext> where TContext : global::System.Data.Entity.DbContext
	{
		public void InitializeDatabase(TContext context)
		{
		}
	}

	#region DbInterceptor
	internal class DbInterceptor : System.Data.Entity.Infrastructure.Interception.IDbCommandInterceptor
	{
		#region IDbCommandInterceptor Members

		void System.Data.Entity.Infrastructure.Interception.IDbCommandInterceptor.NonQueryExecuted(System.Data.Common.DbCommand command, System.Data.Entity.Infrastructure.Interception.DbCommandInterceptionContext<int> interceptionContext)
		{
		}

		void System.Data.Entity.Infrastructure.Interception.IDbCommandInterceptor.NonQueryExecuting(System.Data.Common.DbCommand command, System.Data.Entity.Infrastructure.Interception.DbCommandInterceptionContext<int> interceptionContext)
		{
		}

		void System.Data.Entity.Infrastructure.Interception.IDbCommandInterceptor.ReaderExecuted(System.Data.Common.DbCommand command, System.Data.Entity.Infrastructure.Interception.DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
		{
		}

		void System.Data.Entity.Infrastructure.Interception.IDbCommandInterceptor.ReaderExecuting(System.Data.Common.DbCommand command, System.Data.Entity.Infrastructure.Interception.DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
		{
			try
			{
				//If this is a tenant table then rig query plan for this specific tenant
				if (command.CommandText.Contains("__vw_tenant") || command.CommandText.Contains("__security"))
				{
					var builder = new SqlConnectionStringBuilder(command.Connection.ConnectionString);
					command.CommandText = "--T:" + builder.UserID + "\r\n" + command.CommandText;
				}
				if (GeoLocationEntities.QueryLogger != null)
				{
					var debugInfo = ((IGeoLocationEntities)(interceptionContext.DbContexts.First())).ContextStartup.DebugInfo;
					GeoLocationEntities.QueryLogger(debugInfo + "\r\n" + command.CommandText);
				}
			}
			catch { }
		}

		void System.Data.Entity.Infrastructure.Interception.IDbCommandInterceptor.ScalarExecuted(System.Data.Common.DbCommand command, System.Data.Entity.Infrastructure.Interception.DbCommandInterceptionContext<object> interceptionContext)
		{
		}

		void System.Data.Entity.Infrastructure.Interception.IDbCommandInterceptor.ScalarExecuting(System.Data.Common.DbCommand command, System.Data.Entity.Infrastructure.Interception.DbCommandInterceptionContext<object> interceptionContext)
		{
		}

		#endregion
	}
	#endregion
}

namespace Gravitybox.GeoLocation.EFDAL.Entity
{
}
#pragma warning restore 612

