import { useState, useRef, useEffect } from 'react';
import "./CollapsiblePanel.css"

interface CollapsibleProps {
    title: string;
    children: React.ReactNode;
}

export function CollapsiblePanel({ title, children }: CollapsibleProps) {
    const [isOpen, setIsOpen] = useState(false);
    const [height, setHeight] = useState('0px');
    const contentRef = useRef<HTMLDivElement>(null);

    useEffect(() => {
        if (contentRef.current){
            setHeight(isOpen ? `${contentRef.current.scrollHeight}px` : '0px');
        }
    }, [isOpen]);

    return (
        <div 
            className="collapsible-panel"
            style={{ border: '1px solid #ccc', borderRadius: '4px', margin: '10px 0'}}>
            <button 
                className="collapsible-panel__button"
                onClick={() => setIsOpen(!isOpen)} 
            >
                <span>{title}</span> <span>{isOpen ? 'Retract' : 'Expand' }</span>
            </button>
            <div
                ref={contentRef}
                className='collapsible-panel__content'
                style={{ maxHeight: height }}
            >
                <div className='collapsible-panel__content-inner'>
                    {children}
                </div>
            </div>
        </div>
    );
}