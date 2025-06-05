---
description: Usage of Kraken Link
---

# 毛边的使用

下面我们来看一些例子。

## 例子 1：毛边融合待定数组 <a href="#example-1" id="example-1"></a>

<figure><img src="../../.gitbook/assets/images_0458.png" alt="" width="375"><figcaption><p>毛边融合待定数组</p></figcaption></figure>

如图所示。当如果我们忽略 `r3c6(23)` 的存在的话，那么五个单元格 `r3456c6` 和 `r5c4` 将构成一个标准的融合待定数组，于是所有 1、4、6、7、9 在所在的区域都可以进行删除。

但是很遗憾，他们客观存在。我们无法消除他们，所以值得讨论真假性。将两个候选数当成毛刺看待，于是有四个可能的填数情况。因为同假可以形成结构，所以我们将其分为同假结构和不同假强链的两个情况考虑。

当不同假时，这两个候选数将自动形成强链关系，于是我们可以构造出这个不连续环：

<figure><img src="../../.gitbook/assets/images_0459.png" alt="" width="375"><figcaption><p>强毛边构造不连续环</p></figcaption></figure>

如图所示。链表示如下：

```
5r4c4=(5-2)r4c2=2r8c2-2r8c5=2r2c5-(2=3)r3c6-(3=4)r3c4
```

于是我们可以知道此时 `r4c4 <> 4` 的结论。也就是说可以因为强链毛边关系构成后得到这个删数结论成立。

但是，因为此时 `r4` 具有 4 的共轭对，所以 `r4c6 = 4` 会在 `r4c4 <> 4` 时同步得出。也就是说，强毛边构成时也可以直接得到 `r4c6 = 4` 的结论。

所以，`r2c6(4)` 不论在毛刺同假（融合待定数组成立）还是毛刺不同假（强毛边构成），都可以删除，所以这个题的结论就是 `r2c6 <> 4`。

> 本教程省略了 `r4c46(4)` 共轭对得到 `r4c6 = 4` 造成 `r2c6(4)` 删数的这一幅图。

## 例子 2：毛边摩天楼构造链 <a href="#example-2" id="example-2"></a>

<figure><img src="../../.gitbook/assets/images_0460.png" alt=""><figcaption><p>毛边摩天楼构造删数并延长</p></figcaption></figure>

如左图所示。当 `r2c36(3)` 同为假的时候，我们会有摩天楼，并得到 `r9c1 <> 3` 的结论。得到这个删数因为无法用于后续的结论析取（联立后得出删数结论），所以我们继续延长，和前面分步那样继续延伸一下。

现在看右图。我们从 `r9c1(3)` 为假出发可得到 `r5c2(1)` 为假的结论（因为 `r9c1(3)` 会顺着假设走到 `r7c2(1)` 为真的结论，所以这个结论是可以得出的）。

也就是说，当毛刺 `r2c36(3)` 同假时，有摩天楼成立并最终产生 `r5c2(1)` 的删数结论。这是这一个情况。下面我们来看毛刺不同假的情况。

<figure><img src="../../.gitbook/assets/images_0461.png" alt="" width="375"><figcaption><p>强毛边构造出异数链</p></figcaption></figure>

如图所示。当强毛边成立时有这么一条链：

```
5c5c3=(5-3)r2c3=(3-7)r2c6=7r5c6-7r4c45=2r4c8-2r6c9=5r6c7
```

于是造成删数 `r5c8 <> 5`。不过，因为 `r5c8` 此时是双值格，所以可得 `r5c8 = 1` 的结论。因为此时 `r5c8 = 1` 成立，所以 `r5c2` 也不能填 1。因此，强毛边这个情况成立时候也可以得到 `r5c2 <> 1` 的结论。所以，这个题的结论就是 `r5c2 <> 1`。

> 和前面那个例子一样，本教程也省略了 `r5c8(5)` 删数可得到 `r5c8(1)` 为真，进而删除 `r5c2(1)` 的这一幅图。

## 例子 3：毛边伪数组构造链 <a href="#example-3" id="example-3"></a>

<figure><img src="../../.gitbook/assets/images_0462.png" alt="" width="375"><figcaption><p>毛边伪数组</p></figcaption></figure>

如图所示。如果我们忽略 `r3c6(4)` 和 `r6c6(9)` 两个候选数的话，此时 1、2、3、7 四个数字在 `r356c6` 和 `r5c5` 四个单元格里将构成伪数组结构，但是不能用于删数，因为 7 这个数字的摆放实在是有点“毒辣”。于是我们还是借用前一个例子那样，延长推理。将数字 7 考虑用强链串起来。

<figure><img src="../../.gitbook/assets/images_0463.png" alt="" width="375"><figcaption><p>伪数组构造强链关系，引出连续环</p></figcaption></figure>

如图所示。于是我们就有这样一条链结构，头尾成环。此环可以删除 `r2c5(7)`。

这是当两个毛刺同为假的情况。如果毛刺不同假，则构造强链毛边关系，于是我们又可以找到这么一条链：

<figure><img src="../../.gitbook/assets/images_0464.png" alt="" width="375"><figcaption><p>强毛边构造的毛刺数组链</p></figcaption></figure>

如图所示。当不同假时我们有这个链构成，于是删数仍然囊括 `r2c5(7)`。所以这个题的结论就是 `r2c5 <> 7`。

## 例子 4：毛边对交空矩形构造链 <a href="#example-4" id="example-4"></a>

<figure><img src="../../.gitbook/assets/images_0465.png" alt="" width="375"><figcaption><p>毛边对交空矩形</p></figcaption></figure>

如图所示。如果我们忽略 `r8c5(8)` 和 `r9c9(4)` 的话，此时我们可以利用 `r6c7(49)` 和 `r8c5(49)` 配合 `b9` 将构成对交空矩形结构。还记得这个技巧吗？在之前我们介绍过，它的本质逻辑是串起来的区块环。所以这个技巧可以产生的删数是 `r8c2(4)`。

不过这个删数没有用，后续推理无法用这个数。所以我们需要延长。

<figure><img src="../../.gitbook/assets/images_0466.png" alt="" width="375"><figcaption><p>利用待定数组延长</p></figcaption></figure>

如图所示。于是我们可以得到 `r2c2 <> 1` 的结论。这是毛刺 `r8c5(8)` 和 `r9c9(4)` 同假的情况。

<figure><img src="../../.gitbook/assets/images_0467.png" alt="" width="375"><figcaption><p>强毛边构造异数链</p></figcaption></figure>

如图所示。当毛刺不同假时，我们可以构造出强毛边并得到这个异数链。这个异数链头尾也可以删除 `r2c2(1)`。

所以，这个两个情况均可删除 `r2c2(1)`，因此题的结论就是 `r2c2 <> 1`。

## 例子 5：毛边显性数对构造链 <a href="#example-5" id="example-5"></a>

<figure><img src="../../.gitbook/assets/images_0475.png" alt="" width="375"><figcaption><p>毛刺同假的情况</p></figcaption></figure>

如图所示，我们把 `r8c2(6)` 和 `r9c2(7)` 视为毛刺时，同假则形成 3 和 8 的显性数对，于是可以找到这么一条链，并得到最终 `r9c5(7)` 为真的结果。

<figure><img src="../../.gitbook/assets/images_0476.png" alt="" width="375"><figcaption><p>毛刺不同假的情况</p></figcaption></figure>

如图所示。当毛刺不同假时引出强链关系，于是我们可以构造出图中的环结构，也可以删除 `r9c3(7)`。所以这个题的结论就是 `r9c3 <> 7`。
