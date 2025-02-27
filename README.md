# ASPax Attributes
> ## Este é um fork do repositório https://github.com/dbrizov/NaughtyAttributes
> ### Para mais informações do repositório original acesse:
> ## Documentation
> - [Documentation](https://dbrizov.github.io/na-docs/)
> - [Documentation Repo](https://github.com/dbrizov/na-docs)
> ### Se puder, ajude o desenvolvedor do repositório original com um cafezinho:
> ## Support
> NaughtyAttributes is an open-source project that I am developing in my free time. If you like it you can support me by donating.
> 
> - [PayPal](https://paypal.me/dbrizov)
> - [Buy Me A Coffee](https://www.buymeacoffee.com/dbrizov)
---
[![Unity 2019.4+](https://img.shields.io/badge/unity-2019.4%2B-blue.svg)](https://unity3d.com/get-unity/download)
[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)](https://github.com/adrianuspax/ASPax.Attributes/blob/Modifyed/LICENSE)

ASPax Attributes é uma extensão para o Unity Inspector.

Isso expande a gama de atributos que o Unity fornece para que você possa criar elementos no inspetor poderosos sem a necessidade de editores personalizados ou drawers de propriedade. Ele também fornece atributos que podem ser aplicados a campos ou funções não serializados.

A maioria dos atributos são implementados usando `CustomPropertyDrawer` do Unity, então eles funcionarão em seus editores personalizados.

Os atributos que não funcionarão em seus editores personalizados são os metaatributos e alguns atributos drawers, como
`ReorderableList`, `Button`, `ShowNonSerializedField` e `ShowNativeProperty`.

No entanto, se quiser que todos os atributos funcionem em seus editores personalizados, você deve herdar de `NaughtyInspector` e usar a função `NaughtyEditorGUI.PropertyField_Layout` em vez de `EditorGUILayout.PropertyField`.

## Requirementos
Unity **2019.4** ou versões superiores. Não se esqueça de incluir o namespace ASPax.Attributes.

## Instalação
Use o link https://github.com/adrianuspax/ASPax.Attributes

# Visão geral

## Special Attributes

### AllowNesting
Este atributo deve ser usado em alguns casos quando você deseja que metaatributos funcionem dentro de classes ou estruturas aninhadas serializáveis.

```csharp
public class NaughtyComponent : MonoBehaviour
{
    public MyStruct myStruct;
}

[System.Serializable]
public struct MyStruct
{
    public bool enableFlag;

    [EnableIf("enableFlag")]
    [AllowNesting] // Because it's nested we need to explicitly allow nesting
    public int integer;
}
```

## Drawer Attributes
Forneça opções especiais de desenho para campos serializados.
> Obs. Um campo pode ter apenas um DrawerAttribute. Se um campo tiver mais de um, apenas o inferior será usado.

### AnimatorParam
Selecione um parâmetro do Animator na interface suspensa.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	public Animator someAnimator;

	[AnimatorParam("someAnimator")]
	public int paramHash;

	[AnimatorParam("someAnimator")]
	public string paramName;
}
```

![inspector](Runtime/Documentation~/AnimatorParam_Inspector.png)

### Button
Um método pode ser marcado como um botão. Um botão aparece no inspetor e executa o método se clicado.
Funciona tanto com métodos de instância quanto estáticos.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[Button]
	private void MethodOne() { }

	[Button("Button Text")]
	private void MethodTwo() { }
}
```

![inspector](Runtime//Documentation~/Button_Inspector.png)

### CurveRange
Defina limites e modifique a cor da curva para AnimationCurves

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[CurveRange(-1, -1, 1, 1)]
	public AnimationCurve curve;
	
	[CurveRange(EColor.Orange)]
	public AnimationCurve curve1;
	
	[CurveRange(0, 0, 5, 5, EColor.Red)]
	public AnimationCurve curve2;
}
```

![inspector](Runtime/Documentation~/CurveRange_Inspector.png)

### Dropdown
Fornece uma interface para seleção de valores suspensos.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[Dropdown("intValues")]
	public int intValue;

	[Dropdown("StringValues")]
	public string stringValue;

	[Dropdown("GetVectorValues")]
	public Vector3 vectorValue;

	private int[] intValues = new int[] { 1, 2, 3, 4, 5 };

	private List<string> StringValues { get { return new List<string>() { "A", "B", "C", "D", "E" }; } }

	private DropdownList<Vector3> GetVectorValues()
	{
		return new DropdownList<Vector3>()
		{
			{ "Right",   Vector3.right },
			{ "Left",    Vector3.left },
			{ "Up",      Vector3.up },
			{ "Down",    Vector3.down },
			{ "Forward", Vector3.forward },
			{ "Back",    Vector3.back }
		};
	}
}
```

![inspector](Runtime/Documentation~/Dropdown_Inspector.gif)

### EnumFlags
Fornece interface suspensa para definir sinalizadores de enumeração.

```csharp
public enum Direction
{
	None = 0,
	Right = 1 << 0,
	Left = 1 << 1,
	Up = 1 << 2,
	Down = 1 << 3
}

public class NaughtyComponent : MonoBehaviour
{
	[EnumFlags]
	public Direction flags;
}
```

![inspector](Runtime/Documentation~/EnumFlags_Inspector.png)

### Expandable
Torne objetos programáveis ​​expansíveis.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[Expandable]
	public ScriptableObject scriptableObject;
}
```

![inspector](Runtime/Documentation~/Expandable_Inspector.png)

### HorizontalLine
Linhas horizontais para inspector.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[HorizontalLine(color: EColor.Red)]
	public int red;

	[HorizontalLine(color: EColor.Green)]
	public int green;

	[HorizontalLine(color: EColor.Blue)]
	public int blue;
}
```

![inspector](Runtime/Documentation~/HorizontalLine_Inspector.png)

### InfoBox
Usado para fornecer informações adicionais.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[InfoBox("This is my int", EInfoBoxType.Normal)]
	public int myInt;

	[InfoBox("This is my float", EInfoBoxType.Warning)]
	public float myFloat;

	[InfoBox("This is my vector", EInfoBoxType.Error)]
	public Vector3 myVector;
}
```

![inspector](Runtime/Documentation~/InfoBox_Inspector.png)

### InputAxis
Selecione um eixo de entrada por meio da interface suspensa.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[InputAxis]
	public string inputAxis;
}
```

![inspector](Runtime/Documentation~/InputAxis_Inspector.png)

### Layer
Selecione uma camada na interface suspensa.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[Layer]
	public string layerName;

	[Layer]
	public int layerIndex;
}
```

![inspector](Runtime/Documentation~/Layer_Inspector.png)

### MinMaxSlider
Um controle deslizante duplo. O **valor min** é salvo na propriedade **X**, e o **valor max** é salvo na propriedade **Y** de um campo **Vector2**.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[MinMaxSlider(0.0f, 100.0f)]
	public Vector2 minMaxSlider;
}
```

![inspector](Runtime/Documentation~/MinMaxSlider_Inspector.png)

### ProgressBar
Barra de progresso.
```csharp
public class NaughtyComponent : MonoBehaviour
{
	[ProgressBar("Health", 300, EColor.Red)]
	public int health = 250;

	[ProgressBar("Mana", 100, EColor.Blue)]
	public int mana = 25;

	[ProgressBar("Stamina", 200, EColor.Green)]
	public int stamina = 150;
}
```

![inspector](Runtime/Documentation~/ProgressBar_Inspector.png)

### ReorderableList
Fornece campos do tipo matriz com uma interface para fácil reordenação de elementos.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[ReorderableList]
	public int[] intArray;

	[ReorderableList]
	public List<float> floatArray;
}
```

![inspector](Runtime/Documentation~/ReorderableList_Inspector.gif)

### ResizableTextArea
Uma área de texto redimensionável onde você pode ver o texto inteiro.
Ao contrário dos atributos **Multiline** e **TextArea** do Unity, onde você pode ver apenas 3 linhas de um texto dado, e para vê-lo ou modificá-lo você tem que rolar manualmente para baixo até a linha desejada.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[ResizableTextArea]
	public string resizableTextArea;
}
```

![inspector](Runtime/Documentation~/ResizableTextArea_Inspector.gif)

### Scene
Selecione uma cena nas configurações de construção por meio da interface suspensa.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[Scene]
	public string bootScene; // scene name

	[Scene]
	public int tutorialScene; // scene index
}
```

![inspector](Runtime/Documentation~/Scene_Inspector.png)

### ShowAssetPreview
Mostra a pré-visualização da textura de um determinado ativo (Sprite, Prefab...).

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[ShowAssetPreview]
	public Sprite sprite;

	[ShowAssetPreview(128, 128)]
	public GameObject prefab;
}
```

![inspector](Runtime/Documentation~/ShowAssetPreview_Inspector.png)

### ShowNativeProperty
Mostra propriedades nativas do C# no inspetor.
Todas as propriedades nativas são exibidas na parte inferior do inspetor após os campos não serializados e antes dos botões de método.
Ele suporta apenas certos tipos **(bool, int, long, float, double, string, Vector2, Vector3, Vector4, Color, Bounds, Rect, UnityEngine.Object)**.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	public List<Transform> transforms;

	[ShowNativeProperty]
	public int TransformsCount => transforms.Count;
}
```

![inspector](Runtime/Documentation~/ShowNativeProperty_Inspector.png)

### ShowNonSerializedField
Mostra campos não serializados no inspector.
Todos os campos não serializados são exibidos na parte inferior do inspector antes dos botões de método.
Lembre-se de que se você alterar um campo não serializado não estático no código, o valor no inspetor será atualizado após você pressionar **Play** no editor.
Não há esse problema com campos não serializados estáticos porque seus valores são atualizados em tempo de compilação.
Ele suporta apenas certos tipos **(bool, int, long, float, double, string, Vector2, Vector3, Vector4, Color, Bounds, Rect, UnityEngine.Object)**.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[ShowNonSerializedField]
	private int myInt = 10;

	[ShowNonSerializedField]
	private const float PI = 3.14159f;

	[ShowNonSerializedField]
	private static readonly Vector3 CONST_VECTOR = Vector3.one;
}
```

![inspector](Runtime/Documentation~/ShowNonSerializedField_Inspector.png)

### SortingLayer
Selecione uma Sorting Layer por meio da interface suspensa.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[SortingLayer]
	public string layerName;

	[SortingLayer]
	public int layerId;
}
```

![inspector](Runtime/Documentation~/SortingLayer_Inspector.png)

### Tag
Selecione uma tag na interface suspensa.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[Tag]
	public string tagField;
}
```

![inspector](Runtime/Documentation~/Tag_Inspector.png)

## Meta Attributes
Dê metadados aos campos. Um campo pode ter mais de um atributo meta.

### BoxGroup
Envolve campos agrupados com uma caixa.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[BoxGroup("Integers")]
	public int firstInt;
	[BoxGroup("Integers")]
	public int secondInt;

	[BoxGroup("Floats")]
	public float firstFloat;
	[BoxGroup("Floats")]
	public float secondFloat;
}
```

![inspector](Runtime/Documentation~/BoxGroup_Inspector.png)

### Foldout
Cria um grupo Fold.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[Foldout("Integers")]
	public int firstInt;
	[Foldout("Integers")]
	public int secondInt;
}
```

![inspector](Runtime/Documentation~/Foldout_Inspector.gif)

### EnableIf / DisableIf
Habilita/Desabilita condicionalmente.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	public bool enableMyInt;

	[EnableIf("enableMyInt")]
	public int myInt;

	[EnableIf("Enabled")]
	public float myFloat;

	[EnableIf("NotEnabled")]
	public Vector3 myVector;

	public bool Enabled() { return true; }

	public bool NotEnabled => false;
}
```

![inspector](Runtime/Documentation~/EnableIf_Inspector.gif)

Você pode ter mais de uma condição.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	public bool flag0;
	public bool flag1;

	[EnableIf(EConditionOperator.And, "flag0", "flag1")]
	public int enabledIfAll;

	[EnableIf(EConditionOperator.Or, "flag0", "flag1")]
	public int enabledIfAny;
}
```

### ShowIf / HideIf
Mostra/Esconde condicionalmente.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	public bool showInt;

	[ShowIf("showInt")]
	public int myInt;

	[ShowIf("AlwaysShow")]
	public float myFloat;

	[ShowIf("NeverShow")]
	public Vector3 myVector;

	public bool AlwaysShow() { return true; }

	public bool NeverShow => false;
}
```

![inspector](Runtime/Documentation~/ShowIf_Inspector.gif)

Você pode ter mais de uma condição.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	public bool flag0;
	public bool flag1;

	[ShowIf(EConditionOperator.And, "flag0", "flag1")]
	public int showIfAll;

	[ShowIf(EConditionOperator.Or, "flag0", "flag1")]
	public int showIfAny;
}
```

### Label
Substituir rótulo de campo padrão.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[Label("Short Name")]
	public string veryVeryLongName;

	[Label("RGB")]
	public Vector3 vectorXYZ;
}
```

![inspector](Runtime/Documentation~/Label_Inspector.png)

### OnValueChanged
Detecta uma mudança de valor e executa um retorno de chamada.
Tenha em mente que o evento é detectado somente quando o valor é alterado do inspetor.
Se você quiser um evento de tempo de execução, você provavelmente deve usar um event/delegate e assinar para ele.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[OnValueChanged("OnValueChangedCallback")]
	public int myInt;

	private void OnValueChangedCallback()
	{
		Debug.Log(myInt);
	}
}
```

### ReadOnly
Tornar um campo somente leitura.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[ReadOnly]
	public Vector3 forwardVector = Vector3.forward;
}
```

![inspector](Runtime/Documentation~/ReadOnly_Inspector.png)

## Validator Attributes
Usado para validar os campos. Um campo pode ter um número infinito de atributos validadores.

### MinValue / MaxValue
Fixa campos inteiros e flutuantes.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[MinValue(0), MaxValue(10)]
	public int myInt;

	[MinValue(0.0f)]
	public float myFloat;
}
```

![inspector](Runtime/Documentation~/MinValueMaxValue_Inspector.gif)

### Required
Usado para lembrar o desenvolvedor de que um determinado campo de tipo de referência é obrigatório.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[Required]
	public Transform myTransform;

	[Required("Custom required text")]
	public GameObject myGameObject;
}
```

![inspector](Runtime/Documentation~/Required_Inspector.png)

### ValidateInput
O ValidatorAttribute mais poderoso.

```csharp
public class _NaughtyComponent : MonoBehaviour
{
	[ValidateInput("IsNotNull")]
	public Transform myTransform;

	[ValidateInput("IsGreaterThanZero", "myInteger must be greater than zero")]
	public int myInt;

	private bool IsNotNull(Transform tr)
	{
		return tr != null;
	}

	private bool IsGreaterThanZero(int value)
	{
		return value > 0;
	}
}
```

![inspector](Runtime/Documentation~/ValidateInput_Inspector.png)
