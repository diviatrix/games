using BeardedManStudios.Forge.Networking.Frame;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedInterpol("{\"inter\":[0.15,0.15,0.15,0.15,0,0]")]
	public partial class PlayerNetworkObject : NetworkObject
	{
		public const int IDENTITY = 6;

		private byte[] _dirtyFields = new byte[1];

		#pragma warning disable 0067
		public event FieldChangedEvent fieldAltered;
		#pragma warning restore 0067
		private Vector3 _position;
		public event FieldEvent<Vector3> positionChanged;
		public InterpolateVector3 positionInterpolation = new InterpolateVector3() { LerpT = 0.15f, Enabled = true };
		public Vector3 position
		{
			get { return _position; }
			set
			{
				// Don't do anything if the value is the same
				if (_position == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x1;
				_position = value;
				hasDirtyFields = true;
			}
		}

		public void SetpositionDirty()
		{
			_dirtyFields[0] |= 0x1;
			hasDirtyFields = true;
		}

		private void RunChange_position(ulong timestep)
		{
			if (positionChanged != null) positionChanged(_position, timestep);
			if (fieldAltered != null) fieldAltered("position", _position, timestep);
		}
		private Quaternion _rotation;
		public event FieldEvent<Quaternion> rotationChanged;
		public InterpolateQuaternion rotationInterpolation = new InterpolateQuaternion() { LerpT = 0.15f, Enabled = true };
		public Quaternion rotation
		{
			get { return _rotation; }
			set
			{
				// Don't do anything if the value is the same
				if (_rotation == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x2;
				_rotation = value;
				hasDirtyFields = true;
			}
		}

		public void SetrotationDirty()
		{
			_dirtyFields[0] |= 0x2;
			hasDirtyFields = true;
		}

		private void RunChange_rotation(ulong timestep)
		{
			if (rotationChanged != null) rotationChanged(_rotation, timestep);
			if (fieldAltered != null) fieldAltered("rotation", _rotation, timestep);
		}
		private Vector3 _velocity;
		public event FieldEvent<Vector3> velocityChanged;
		public InterpolateVector3 velocityInterpolation = new InterpolateVector3() { LerpT = 0.15f, Enabled = true };
		public Vector3 velocity
		{
			get { return _velocity; }
			set
			{
				// Don't do anything if the value is the same
				if (_velocity == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x4;
				_velocity = value;
				hasDirtyFields = true;
			}
		}

		public void SetvelocityDirty()
		{
			_dirtyFields[0] |= 0x4;
			hasDirtyFields = true;
		}

		private void RunChange_velocity(ulong timestep)
		{
			if (velocityChanged != null) velocityChanged(_velocity, timestep);
			if (fieldAltered != null) fieldAltered("velocity", _velocity, timestep);
		}
		private Quaternion _modelRotation;
		public event FieldEvent<Quaternion> modelRotationChanged;
		public InterpolateQuaternion modelRotationInterpolation = new InterpolateQuaternion() { LerpT = 0.15f, Enabled = true };
		public Quaternion modelRotation
		{
			get { return _modelRotation; }
			set
			{
				// Don't do anything if the value is the same
				if (_modelRotation == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x8;
				_modelRotation = value;
				hasDirtyFields = true;
			}
		}

		public void SetmodelRotationDirty()
		{
			_dirtyFields[0] |= 0x8;
			hasDirtyFields = true;
		}

		private void RunChange_modelRotation(ulong timestep)
		{
			if (modelRotationChanged != null) modelRotationChanged(_modelRotation, timestep);
			if (fieldAltered != null) fieldAltered("modelRotation", _modelRotation, timestep);
		}
		private bool _isMoving;
		public event FieldEvent<bool> isMovingChanged;
		public Interpolated<bool> isMovingInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool isMoving
		{
			get { return _isMoving; }
			set
			{
				// Don't do anything if the value is the same
				if (_isMoving == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x10;
				_isMoving = value;
				hasDirtyFields = true;
			}
		}

		public void SetisMovingDirty()
		{
			_dirtyFields[0] |= 0x10;
			hasDirtyFields = true;
		}

		private void RunChange_isMoving(ulong timestep)
		{
			if (isMovingChanged != null) isMovingChanged(_isMoving, timestep);
			if (fieldAltered != null) fieldAltered("isMoving", _isMoving, timestep);
		}
		private bool _isAttacking;
		public event FieldEvent<bool> isAttackingChanged;
		public Interpolated<bool> isAttackingInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool isAttacking
		{
			get { return _isAttacking; }
			set
			{
				// Don't do anything if the value is the same
				if (_isAttacking == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x20;
				_isAttacking = value;
				hasDirtyFields = true;
			}
		}

		public void SetisAttackingDirty()
		{
			_dirtyFields[0] |= 0x20;
			hasDirtyFields = true;
		}

		private void RunChange_isAttacking(ulong timestep)
		{
			if (isAttackingChanged != null) isAttackingChanged(_isAttacking, timestep);
			if (fieldAltered != null) fieldAltered("isAttacking", _isAttacking, timestep);
		}

		protected override void OwnershipChanged()
		{
			base.OwnershipChanged();
			SnapInterpolations();
		}
		
		public void SnapInterpolations()
		{
			positionInterpolation.current = positionInterpolation.target;
			rotationInterpolation.current = rotationInterpolation.target;
			velocityInterpolation.current = velocityInterpolation.target;
			modelRotationInterpolation.current = modelRotationInterpolation.target;
			isMovingInterpolation.current = isMovingInterpolation.target;
			isAttackingInterpolation.current = isAttackingInterpolation.target;
		}

		public override int UniqueIdentity { get { return IDENTITY; } }

		protected override BMSByte WritePayload(BMSByte data)
		{
			UnityObjectMapper.Instance.MapBytes(data, _position);
			UnityObjectMapper.Instance.MapBytes(data, _rotation);
			UnityObjectMapper.Instance.MapBytes(data, _velocity);
			UnityObjectMapper.Instance.MapBytes(data, _modelRotation);
			UnityObjectMapper.Instance.MapBytes(data, _isMoving);
			UnityObjectMapper.Instance.MapBytes(data, _isAttacking);

			return data;
		}

		protected override void ReadPayload(BMSByte payload, ulong timestep)
		{
			_position = UnityObjectMapper.Instance.Map<Vector3>(payload);
			positionInterpolation.current = _position;
			positionInterpolation.target = _position;
			RunChange_position(timestep);
			_rotation = UnityObjectMapper.Instance.Map<Quaternion>(payload);
			rotationInterpolation.current = _rotation;
			rotationInterpolation.target = _rotation;
			RunChange_rotation(timestep);
			_velocity = UnityObjectMapper.Instance.Map<Vector3>(payload);
			velocityInterpolation.current = _velocity;
			velocityInterpolation.target = _velocity;
			RunChange_velocity(timestep);
			_modelRotation = UnityObjectMapper.Instance.Map<Quaternion>(payload);
			modelRotationInterpolation.current = _modelRotation;
			modelRotationInterpolation.target = _modelRotation;
			RunChange_modelRotation(timestep);
			_isMoving = UnityObjectMapper.Instance.Map<bool>(payload);
			isMovingInterpolation.current = _isMoving;
			isMovingInterpolation.target = _isMoving;
			RunChange_isMoving(timestep);
			_isAttacking = UnityObjectMapper.Instance.Map<bool>(payload);
			isAttackingInterpolation.current = _isAttacking;
			isAttackingInterpolation.target = _isAttacking;
			RunChange_isAttacking(timestep);
		}

		protected override BMSByte SerializeDirtyFields()
		{
			dirtyFieldsData.Clear();
			dirtyFieldsData.Append(_dirtyFields);

			if ((0x1 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _position);
			if ((0x2 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _rotation);
			if ((0x4 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _velocity);
			if ((0x8 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _modelRotation);
			if ((0x10 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _isMoving);
			if ((0x20 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _isAttacking);

			// Reset all the dirty fields
			for (int i = 0; i < _dirtyFields.Length; i++)
				_dirtyFields[i] = 0;

			return dirtyFieldsData;
		}

		protected override void ReadDirtyFields(BMSByte data, ulong timestep)
		{
			if (readDirtyFlags == null)
				Initialize();

			Buffer.BlockCopy(data.byteArr, data.StartIndex(), readDirtyFlags, 0, readDirtyFlags.Length);
			data.MoveStartIndex(readDirtyFlags.Length);

			if ((0x1 & readDirtyFlags[0]) != 0)
			{
				if (positionInterpolation.Enabled)
				{
					positionInterpolation.target = UnityObjectMapper.Instance.Map<Vector3>(data);
					positionInterpolation.Timestep = timestep;
				}
				else
				{
					_position = UnityObjectMapper.Instance.Map<Vector3>(data);
					RunChange_position(timestep);
				}
			}
			if ((0x2 & readDirtyFlags[0]) != 0)
			{
				if (rotationInterpolation.Enabled)
				{
					rotationInterpolation.target = UnityObjectMapper.Instance.Map<Quaternion>(data);
					rotationInterpolation.Timestep = timestep;
				}
				else
				{
					_rotation = UnityObjectMapper.Instance.Map<Quaternion>(data);
					RunChange_rotation(timestep);
				}
			}
			if ((0x4 & readDirtyFlags[0]) != 0)
			{
				if (velocityInterpolation.Enabled)
				{
					velocityInterpolation.target = UnityObjectMapper.Instance.Map<Vector3>(data);
					velocityInterpolation.Timestep = timestep;
				}
				else
				{
					_velocity = UnityObjectMapper.Instance.Map<Vector3>(data);
					RunChange_velocity(timestep);
				}
			}
			if ((0x8 & readDirtyFlags[0]) != 0)
			{
				if (modelRotationInterpolation.Enabled)
				{
					modelRotationInterpolation.target = UnityObjectMapper.Instance.Map<Quaternion>(data);
					modelRotationInterpolation.Timestep = timestep;
				}
				else
				{
					_modelRotation = UnityObjectMapper.Instance.Map<Quaternion>(data);
					RunChange_modelRotation(timestep);
				}
			}
			if ((0x10 & readDirtyFlags[0]) != 0)
			{
				if (isMovingInterpolation.Enabled)
				{
					isMovingInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					isMovingInterpolation.Timestep = timestep;
				}
				else
				{
					_isMoving = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_isMoving(timestep);
				}
			}
			if ((0x20 & readDirtyFlags[0]) != 0)
			{
				if (isAttackingInterpolation.Enabled)
				{
					isAttackingInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					isAttackingInterpolation.Timestep = timestep;
				}
				else
				{
					_isAttacking = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_isAttacking(timestep);
				}
			}
		}

		public override void InterpolateUpdate()
		{
			if (IsOwner)
				return;

			if (positionInterpolation.Enabled && !positionInterpolation.current.UnityNear(positionInterpolation.target, 0.0015f))
			{
				_position = (Vector3)positionInterpolation.Interpolate();
				//RunChange_position(positionInterpolation.Timestep);
			}
			if (rotationInterpolation.Enabled && !rotationInterpolation.current.UnityNear(rotationInterpolation.target, 0.0015f))
			{
				_rotation = (Quaternion)rotationInterpolation.Interpolate();
				//RunChange_rotation(rotationInterpolation.Timestep);
			}
			if (velocityInterpolation.Enabled && !velocityInterpolation.current.UnityNear(velocityInterpolation.target, 0.0015f))
			{
				_velocity = (Vector3)velocityInterpolation.Interpolate();
				//RunChange_velocity(velocityInterpolation.Timestep);
			}
			if (modelRotationInterpolation.Enabled && !modelRotationInterpolation.current.UnityNear(modelRotationInterpolation.target, 0.0015f))
			{
				_modelRotation = (Quaternion)modelRotationInterpolation.Interpolate();
				//RunChange_modelRotation(modelRotationInterpolation.Timestep);
			}
			if (isMovingInterpolation.Enabled && !isMovingInterpolation.current.UnityNear(isMovingInterpolation.target, 0.0015f))
			{
				_isMoving = (bool)isMovingInterpolation.Interpolate();
				//RunChange_isMoving(isMovingInterpolation.Timestep);
			}
			if (isAttackingInterpolation.Enabled && !isAttackingInterpolation.current.UnityNear(isAttackingInterpolation.target, 0.0015f))
			{
				_isAttacking = (bool)isAttackingInterpolation.Interpolate();
				//RunChange_isAttacking(isAttackingInterpolation.Timestep);
			}
		}

		private void Initialize()
		{
			if (readDirtyFlags == null)
				readDirtyFlags = new byte[1];

		}

		public PlayerNetworkObject() : base() { Initialize(); }
		public PlayerNetworkObject(NetWorker networker, INetworkBehavior networkBehavior = null, int createCode = 0, byte[] metadata = null) : base(networker, networkBehavior, createCode, metadata) { Initialize(); }
		public PlayerNetworkObject(NetWorker networker, uint serverId, FrameStream frame) : base(networker, serverId, frame) { Initialize(); }

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}
