﻿using UnityEngine;

using XNode.Editor;

namespace FSM.Editor
{
	[CustomNodeEditor( typeof( FSMNode ) )]
	public class FSMNodeEditor : XNode.Editor.NodeEditor
	{
		private Color? _nodeColor;
		protected FSMNode Target => target as FSMNode;

		private Color _NodeColor
		{
			get
			{
				if ( _nodeColor.HasValue )
				{
					return _nodeColor.Value;
				}

				_nodeColor = Target.Color;
				return _nodeColor.Value;
			}
		}

		public override void OnHeaderGUI()
		{
			GUILayout.Label( Target.Name, NodeEditorResources.styles.nodeHeader, GUILayout.Height( 30 ) );
			var configuration = Target.IsRightConfigured();
			if ( !configuration.Item1 )
			{
				GUILayout.Label( configuration.Item2, NodeEditorResources.styles.nodeErrorHeader );
			}
		}

		public override Color GetTint()
		{
			if ( !Target.IsRightConfigured().Item1 )
			{
				return Color.red;
			}
			return _NodeColor;
		}
	}

	public abstract class FSMNodeEditor<T> : FSMNodeEditor where T : FSMNode
	{
		protected new T Target => base.Target as T;
	}
}