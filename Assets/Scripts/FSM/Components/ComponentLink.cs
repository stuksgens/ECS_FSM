using Rotorz.Games;

using System;

using Unity.Entities;

using UnityEngine;

using XNode;

namespace FSM.Components
{
	[Flags]
	public enum ComponentLinkAccessType
	{
		Unused = 0,
		R = 1 << 0,
		W = 1 << 1,
		RW = R | W,
	}

	public enum ComponentLinkUsageType
	{
		Invalid = 0,
		All = 1,
		Any = 2,
		None = 3,
	}

	[Serializable]
	public class ComponentLink
	{
		[SerializeField]
		[ClassImplements( typeof( IComponentData ) )]
		private ClassTypeReference _componentTypeReference = default;

		[SerializeField]
		private string _componentName;

		[SerializeField, NodeEnum]
		private ComponentLinkAccessType _accessType;

		[SerializeField, NodeEnum]
		private ComponentLinkUsageType _usageType;
	}
}