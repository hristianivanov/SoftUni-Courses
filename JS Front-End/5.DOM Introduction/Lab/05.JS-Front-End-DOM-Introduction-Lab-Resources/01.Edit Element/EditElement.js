function editElement(ref,match,replacer) {
    const content = ref.textContent;
    const regex = new RegExp(match,"g");
    ref.textContent = content.replace(regex,replacer);
}