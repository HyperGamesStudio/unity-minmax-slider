
using UnityEngine;
using UnityEditor;


[CustomPropertyDrawer (typeof (MinMaxSliderAttribute))]
class MinMaxSliderDrawer : PropertyDrawer {

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {

		if (property.propertyType == SerializedPropertyType.Vector2) {
			Vector2 range = property.vector2Value;
			float min = range.x;
			float max = range.y;
			MinMaxSliderAttribute attr = attribute as MinMaxSliderAttribute;

			float componentHeight = 16.0f;
			float verticalPadding = 2.0f;

			label = EditorGUI.BeginProperty(position, label, property);

			Rect sliderRect = new Rect(position.x,
			                           position.y,
			                           position.width,
			                           componentHeight);

			Rect lower = EditorGUI.PrefixLabel(sliderRect, label);
			lower.y += componentHeight + verticalPadding;

			Rect upper = new Rect(lower.x,
			                      lower.y + componentHeight + verticalPadding,
			                      lower.width,
			                      componentHeight);

			EditorGUI.BeginChangeCheck();
			EditorGUI.MinMaxSlider(label, sliderRect, ref min, ref max, attr.min, attr.max);

			min = EditorGUI.FloatField(lower, "Lower", min);
			max = EditorGUI.FloatField(upper, "Upper", max);

			if (EditorGUI.EndChangeCheck()) {
				range.x = min;
				range.y = max;
				property.vector2Value = range;
			}

			EditorGUI.EndProperty();

		} else {
			EditorGUI.LabelField (position, label, "Use only with Vector2");
		}
	}

	override public float GetPropertyHeight(SerializedProperty property, GUIContent label) {
		return base.GetPropertyHeight(property, label) + 18.0f + 18.0f;
	}
}
