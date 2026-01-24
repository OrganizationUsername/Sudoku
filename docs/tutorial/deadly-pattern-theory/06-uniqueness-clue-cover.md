---
description: Uniqueness Clue Cover
---

# 唯一性提示数覆盖（UCC）

下面要介绍一个只能计算机才能证明的致命结构类型。

## 唯一性提示数覆盖的基本推理 <a href="#reasoning-of-uniqueness-clue-cover" id="reasoning-of-uniqueness-clue-cover"></a>

<figure><img src="../.gitbook/assets/images_0936.png" alt="" width="375"><figcaption><p>唯一性提示数覆盖</p></figcaption></figure>

如图所示。我们发现，这个结构的第一个大行只有两个提示数 1 和 2，分别位于 `r3c6` 和 `r2c9`。

一旦我们发现如下的条&#x4EF6;_&#x5168;&#x90E8;_&#x6210;立的时候：

1. 一个大行（或大列）只有 2 个提示数；
2. 两个提示数分布在两个不同的宫里；
3. 两个提示数不能同在一个行列上；
4. 两个提示数的数值上不同；
5. 这个题是唯一解的。

当这几点同时满足的时候，我们就可以得到这样的结论：

**如果整个结构按大行来看的话，就找到两个提示数所在列上的 3 个格子（如果按大列看的话，那么就找行上的 3 个格子）。然后，除开自身还有 4 个单元格，然后只取其中唯二满足的单元格，不被同时两个提示数所看见的格子。这两个单元格里，如果提示数分别是** $$a$$ **和** $$b$$ **的话，那么只能被** $$a$$ **提示数看见的单元格就必须填** $$b$$**，而只能被** $$b$$ **看见的单元格就必须填** $$a$$**。**

所以，这个题的结论是 `r1c6` 填 2，而 `r1c9` 填 1。

我们把这个技巧称为**唯一性提示数覆盖**（Uniqueness Clue Cover，简称 UCC）。可以从名字看出，这个技巧只跟提示数有关。

## 该技巧只能被计算机证明 <a href="#this-technique-can-be-only-proved-by-computer" id="this-technique-can-be-only-proved-by-computer"></a>

早在上一个版本的教程里，我强行使用了人工进行了一轮证明，用大约 10 页 A4 纸大小的页面（当时写的是电子文档）为此技巧进行了完整的推算和证明。但是很不幸的是，技巧的证明里有一处非常严重的漏洞。在和邱言哲（就是之前提出宇宙法名称的那位）讨论了之后，因为漏洞无法通过子情况讨论的形式进行（因为实在是太过复杂了），所以那个证明本教程版本里就不再被采用了；而这里我们也不会针对此漏洞作出过多说明，这已经不重要了。

我知道很遗憾，但这一处漏洞是致命的漏洞。各种意义上的致命（致命结构的“致命”？过于严重的“致命”？也许吧，都可以算是吧）。

该技巧牵扯到的是非常复杂和暴力的穷举。它需要讨论整个大行列余下 25 个单元格的全部可能摆放情况，对于唯一解的题里都需要进行一轮校验，并确保每一种填法下余下的单元格都能形成致命形式（如唯一矩形或唯一环，甚至才讲没多久的唯一矩阵、匿名致命结构等等结构的其中一个或多个组合的致命形式）。

它的穷举不仅仅是只跟讨论矛盾有关，而图中可见的结论（`r1c6 = 2` 和 `r1c9 = 1` 的结论）都是穷举所必要的一环。这里我们是把他包装成了出数结论，但实际上它的结论是 `r1c6 <> 34569` 和 `r1c9 <> 3569` 这一部分，即视为删数技巧。总之，程序依靠全盘穷举排列后发现无法被覆盖到的候选数（即所有填数情况都不可能造成的出数），即为这个技巧的删数结论。如 `r1c6` 所谓删除的这些数字，其原因是通过穷举后得到，全部可能的排列下，`r1c6` 合理填法都不可能有 3、4、5、6、9 这些候选数作为填入；同理，`r1c9` 的 3、5、6、9 候选数也是一样。因为穷举层面都根本不会出现，所以它必然不会作为解的一部分，因此删掉他们。这便是这个技巧的计算机层面的验证过程。

## 变体类型 <a href="#variant-types-of-uniqueness-clue-cover" id="variant-types-of-uniqueness-clue-cover"></a>

该技巧既然是电脑穷举得到的，那么它自然就不可能只有这一种样貌。下面我们来看看别的。

### 例子 1 <a href="#example-1" id="example-1"></a>

<figure><img src="../.gitbook/assets/images_0937.png" alt="" width="375"><figcaption><p>例子 1</p></figcaption></figure>

如图所示。当第一大行里有 3 个提示数时，且只用两种数字，其中两个和第一种标准类型长相一样，第三个提示数则位于两个提示数都看得见的其中一个单元格里的话，那么它构成了其中一种唯一性提示数覆盖的矛盾情况。其结论是，删除第三个宫里（三个提示数都不在的宫）里，不同于三个提示数所在行列的 3 个单元格的 2，以及宫里只含有 1 个提示数的那个宫里，从两个来自不同宫的提示数都看得见的交集上出发的这个空矩形的四个格子的 2。

说起来很绕，实际上是这样的。

<figure><img src="../.gitbook/assets/images_0938.png" alt="" width="375"><figcaption><p>删数范围</p></figcaption></figure>

如图所示。`r1c2(2)` 不存在，是因为 `r8c2` 是提示数 2 已经排除掉了这个地方是 2 的可能性。

### 例子 2 <a href="#example-2" id="example-2"></a>

<figure><img src="../.gitbook/assets/images_0945.png" alt="" width="375"><figcaption><p>例子 2</p></figcaption></figure>

如图所示。如果一个完整的大行包含 9 个单元格是提示数，并且符合 3 行 3 列的分布，且处于四个角的、互为对角线上的两个角上包含不同的数字，另外一侧是相同数字，连线上也是这个数，然后余下的 4 个格子按刚才对角线走向延伸被分割为两对单元格，每一对都是同一种数字，且总体结构包含 5 种不同的数字的时候，它就可以形成删数。删数的范围是这些：

<figure><img src="../.gitbook/assets/images_0946.png" alt="" width="375"><figcaption><p>删数范围</p></figcaption></figure>

如图所示。

## 目前已知的类型 <a href="#all-known-types-of-uniqueness-clue-cover" id="all-known-types-of-uniqueness-clue-cover"></a>

这个技巧的实际用例就只有几个。但是计算机算出来的却不只是这几个。下面我们来看一些示意图。

### 类型 1 <a href="#type-1" id="type-1"></a>

<figure><img src="../.gitbook/assets/images_0939.png" alt="" width="375"><figcaption><p>类型 1</p></figcaption></figure>

### 类型 2 <a href="#type-2" id="type-2"></a>

<figure><img src="../.gitbook/assets/images_0940.png" alt="" width="375"><figcaption><p>类型 2</p></figcaption></figure>

### 类型 3 <a href="#type-3" id="type-3"></a>

<figure><img src="../.gitbook/assets/images_0941.png" alt="" width="375"><figcaption><p>类型 3</p></figcaption></figure>

### 类型 4 <a href="#type-4" id="type-4"></a>

<figure><img src="../.gitbook/assets/images_0942.png" alt="" width="375"><figcaption><p>类型 4</p></figcaption></figure>

### 类型 5 <a href="#type-5" id="type-5"></a>

<figure><img src="../.gitbook/assets/images_0943.png" alt="" width="375"><figcaption><p>类型 5</p></figcaption></figure>

### 类型 6 <a href="#type-6" id="type-6"></a>

<figure><img src="../.gitbook/assets/images_0944.png" alt="" width="375"><figcaption><p>类型 6</p></figcaption></figure>

### 类型 7 <a href="#type-7" id="type-7"></a>

<figure><img src="../.gitbook/assets/images_0947.png" alt="" width="375"><figcaption><p>类型 7</p></figcaption></figure>

可能还存在其他的构型，但我在翻阅资料的时候并未找到他们；我能找到的是这些，并且其中很多构型都并未给出例子。我想只是因为单纯出不出来难度契合还包含有效删数的好例子用于介绍吧。那这个技巧就介绍到这里吧。这种只能依靠计算机穷举的确实不是一个好理解的东西。
